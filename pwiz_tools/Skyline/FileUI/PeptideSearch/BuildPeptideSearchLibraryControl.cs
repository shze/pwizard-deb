/*
 * Original author: Tahmina Jahan <tabaker .at. u.washington.edu>,
 *                  UWPR, Department of Genome Sciences, UW
 *
 * Copyright 2012 University of Washington - Seattle, WA
 * 
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *     http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using pwiz.Common.Collections;
using pwiz.Common.SystemUtil;
using pwiz.Skyline.Alerts;
using pwiz.Skyline.Controls;
using pwiz.Skyline.Model;
using pwiz.Skyline.Model.Irt;
using pwiz.Skyline.Model.Lib;
using pwiz.Skyline.Properties;
using pwiz.Skyline.SettingsUI;
using pwiz.Skyline.SettingsUI.Irt;
using pwiz.Skyline.Util;
using pwiz.Skyline.Util.Extensions;

namespace pwiz.Skyline.FileUI.PeptideSearch
{
    public partial class BuildPeptideSearchLibraryControl : UserControl
    {
        public BuildPeptideSearchLibraryControl(SkylineWindow skylineWindow, ImportPeptideSearch importPeptideSearch, LibraryManager libraryManager)
        {
            SkylineWindow = skylineWindow;
            ImportPeptideSearch = importPeptideSearch;
            LibraryManager = libraryManager;

            InitializeComponent();

            textCutoff.Text = ImportPeptideSearch.CutoffScore.ToString(LocalizationHelper.CurrentCulture);

            if (SkylineWindow.Document.PeptideCount == 0)
                cbFilterForDocumentPeptides.Hide();

            foreach (var standard in IrtStandard.ALL)
                comboStandards.Items.Add(standard);
        }

        public event EventHandler<InputFilesChangedEventArgs> InputFilesChanged;

        private void FireInputFilesChanged(InputFilesChangedEventArgs e)
        {
            if (InputFilesChanged != null)
            {
                InputFilesChanged(this, e);
            }
        }

        private SkylineWindow SkylineWindow { get; set; }
        private LibraryManager LibraryManager { get; set; }
        private ImportPeptideSearch ImportPeptideSearch { get; set; }

        private Form WizardForm
        {
            get { return FormEx.GetParentForm(this); }
        }

        public IrtStandard IrtStandards
        {
            get { return comboStandards.SelectedItem as IrtStandard; }
            set
            {
                if (value == null)
                    comboStandards.SelectedIndex = 0;

                for (var i = 0; i < comboStandards.Items.Count; i++)
                {
                    if (comboStandards.Items[i] == value)
                    {
                        comboStandards.SelectedIndex = i;
                        return;
                    }
                }
                comboStandards.SelectedIndex = 0;
            }
        }

        public ImportPeptideSearchDlg.Workflow WorkflowType
        {
            get
            {
                if (radioPRM.Checked)
                    return ImportPeptideSearchDlg.Workflow.prm;
                if (radioDIA.Checked)
                    return ImportPeptideSearchDlg.Workflow.dia;
                return ImportPeptideSearchDlg.Workflow.dda;
            }
            set
            {
                switch (value)
                {
                    case ImportPeptideSearchDlg.Workflow.prm:
                        radioPRM.Checked = true;
                        break;
                    case ImportPeptideSearchDlg.Workflow.dia:
                        radioDIA.Checked = true;
                        break;
                    default:
                        radioDDA.Checked = true;
                        break;
                }
            }
        }

        public bool FilterForDocumentPeptides
        {
            get { return cbFilterForDocumentPeptides.Checked; }
            set { cbFilterForDocumentPeptides.Checked = value; }
        }

        public string[] SearchFilenames
        {
            get { return ImportPeptideSearch.SearchFilenames; }

            private set
            {
                // Set new value
                ImportPeptideSearch.SearchFilenames = value;

                // Always show sorted list of files
                Array.Sort(ImportPeptideSearch.SearchFilenames);

                // Calculate the common root directory
                string dirInputRoot = PathEx.GetCommonRoot(ImportPeptideSearch.SearchFilenames);

                // Populate the input files list
                listSearchFiles.BeginUpdate();
                listSearchFiles.Items.Clear();
                foreach (string fileName in ImportPeptideSearch.SearchFilenames)
                {
                    listSearchFiles.Items.Add(fileName.Substring(dirInputRoot.Length));
                }
                listSearchFiles.EndUpdate();

                FireInputFilesChanged(new InputFilesChangedEventArgs(listSearchFiles.Items.Count));
            }
        }

        private void btnRemFile_Click(object sender, EventArgs e)
        {
            RemoveFiles();
        }

        public void RemoveFiles()
        {
            var selectedIndices = listSearchFiles.SelectedIndices;
            var listSearchFilenames = SearchFilenames.ToList();
            for (int i = selectedIndices.Count - 1; i >= 0; i--)
            {
                listSearchFiles.Items.RemoveAt(i);
                listSearchFilenames.RemoveAt(i);
            }
            SearchFilenames = listSearchFilenames.ToArray();

            FireInputFilesChanged(new InputFilesChangedEventArgs(listSearchFiles.Items.Count));
        }

        private void listSearchFiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnRemFile.Enabled = listSearchFiles.SelectedItems.Count > 0;
        }

        private void btnAddFile_Click(object sender, EventArgs e)
        {
            string[] addFiles = BuildLibraryDlg.ShowAddFile(WizardForm, Path.GetDirectoryName(SkylineWindow.DocumentFilePath));
            if (addFiles != null)
            {
                AddSearchFiles(addFiles);
            }
        }

        public void AddSearchFiles(IEnumerable<string> fileNames)
        {
            SearchFilenames = BuildLibraryDlg.AddInputFiles(WizardForm, SearchFilenames, fileNames);
        }

        public double CutOffScore
        {
            get { return double.Parse(textCutoff.Text); }
            set { textCutoff.Text = value.ToString(CultureInfo.CurrentCulture); }
        }

        public bool BuildPeptideSearchLibrary(CancelEventArgs e)
        {
            // Nothing to build, if now search files were specified
            if (!SearchFilenames.Any())
            {
                var libraries = SkylineWindow.Document.Settings.PeptideSettings.Libraries;
                if (!libraries.HasLibraries)
                    return false;
                var libSpec = libraries.LibrarySpecs.FirstOrDefault(s => s.IsDocumentLibrary);
                return libSpec != null && LoadPeptideSearchLibrary(libSpec);
            }

            double cutOffScore;
            MessageBoxHelper helper = new MessageBoxHelper(WizardForm);
            if (!helper.ValidateDecimalTextBox(textCutoff, 0, 1.0, out cutOffScore))
            {
                e.Cancel = true;
                return false;
            }
            ImportPeptideSearch.CutoffScore = cutOffScore;

            BiblioSpecLiteBuilder builder;
            try
            {
                builder = ImportPeptideSearch.GetLibBuilder(SkylineWindow.Document, SkylineWindow.DocumentFilePath, cbIncludeAmbiguousMatches.Checked);
            }
            catch (FileEx.DeleteException de)
            {
                MessageDlg.ShowException(this, de);
                return false;
            }

            using (var longWaitDlg = new LongWaitDlg
            {
                Text = Resources.BuildPeptideSearchLibraryControl_BuildPeptideSearchLibrary_Building_Peptide_Search_Library,
                Message = Resources.BuildPeptideSearchLibraryControl_BuildPeptideSearchLibrary_Building_document_library_for_peptide_search_,
            })
            {
                // Disable the wizard, because the LongWaitDlg does not
                try
                {
                    ImportPeptideSearch.ClosePeptideSearchLibraryStreams(SkylineWindow.DocumentUI);
                    var status = longWaitDlg.PerformWork(WizardForm, 800,
                        monitor => LibraryManager.BuildLibraryBackground(SkylineWindow, builder, monitor, new LibraryManager.BuildState(null, null)));
                    if (status.IsError)
                    {
                        MessageDlg.ShowException(WizardForm, status.ErrorException);
                        return false;
                    }
                }
                catch (Exception x)
                {
                    MessageDlg.ShowWithException(WizardForm, TextUtil.LineSeparate(string.Format(Resources.BuildPeptideSearchLibraryControl_BuildPeptideSearchLibrary_Failed_to_build_the_library__0__,
                        Path.GetFileName(BiblioSpecLiteSpec.GetLibraryFileName(SkylineWindow.DocumentFilePath))), x.Message), x);
                    return false;
                }
            }

            var docLibSpec = builder.LibrarySpec.ChangeDocumentLibrary(true);
            Settings.Default.SpectralLibraryList.Insert(0, docLibSpec);

            // Go ahead and load the library - we'll need it for 
            // the modifications and chromatograms page.
            if (!LoadPeptideSearchLibrary(docLibSpec))
                return false;

            var selectedIrtStandard = comboStandards.SelectedItem as IrtStandard;
            if (selectedIrtStandard != null && selectedIrtStandard != IrtStandard.NULL)
                AddIrtLibraryTable(docLibSpec.FilePath, selectedIrtStandard);

            var docNew = ImportPeptideSearch.AddDocumentSpectralLibrary(SkylineWindow.Document, docLibSpec);
            if (docNew == null)
                return false;

            SkylineWindow.ModifyDocument(Resources.BuildPeptideSearchLibraryControl_BuildPeptideSearchLibrary_Add_document_spectral_library, doc => docNew);

            if (!string.IsNullOrEmpty(builder.AmbiguousMatchesMessage))
            {
                MessageDlg.Show(WizardForm, builder.AmbiguousMatchesMessage);
            }
            return true;
        }

        private bool LoadPeptideSearchLibrary(LibrarySpec docLibSpec)
        {
            if (docLibSpec == null)
                return false;

            using (var longWait = new LongWaitDlg
            {
                Text = Resources.BuildPeptideSearchLibraryControl_LoadPeptideSearchLibrary_Loading_Library
            })
            {
                try
                {
                    var status = longWait.PerformWork(WizardForm, 800, monitor => ImportPeptideSearch.LoadPeptideSearchLibrary(LibraryManager, docLibSpec, monitor));
                    if (status.IsError)
                    {
                        MessageDlg.ShowException(WizardForm, status.ErrorException);
                    }
                }
                catch (Exception x)
                {
                    MessageDlg.ShowWithException(WizardForm,
                        TextUtil.LineSeparate(string.Format(Resources.BuildPeptideSearchLibraryControl_LoadPeptideSearchLibrary_An_error_occurred_attempting_to_import_the__0__library_,
                            docLibSpec.Name), x.Message), x);
                }
            }
            return ImportPeptideSearch.HasDocLib;
        }

        private void AddIrtLibraryTable(string path, IrtStandard standard)
        {
            if (!ImportPeptideSearch.HasDocLib || !ImportPeptideSearch.DocLib.IsLoaded)
                return;

            var lib = ImportPeptideSearch.DocLib;

            ProcessedIrtAverages processed = null;
            using (var longWait = new LongWaitDlg
            {
                Text = Resources.BuildPeptideSearchLibraryControl_AddIrtLibraryTable_Processing_Retention_Times
            })
            {
                try
                {
                    var status = longWait.PerformWork(WizardForm, 800, monitor =>
                    {
                        var irtProviders = lib.RetentionTimeProvidersIrt.ToArray();
                        if (!irtProviders.Any())
                            irtProviders = lib.RetentionTimeProviders.ToArray();
                        processed = RCalcIrt.ProcessRetentionTimes(monitor, irtProviders, irtProviders.Length, standard.Peptides.ToArray(), new DbIrtPeptide[0]);
                    });
                    if (status.IsError)
                        throw status.ErrorException;
                }
                catch (Exception x)
                {
                    MessageDlg.ShowWithException(WizardForm,
                        TextUtil.LineSeparate(Resources.BuildPeptideSearchLibraryControl_AddIrtLibraryTable_An_error_occurred_while_processing_retention_times_, x.Message), x);
                    return;
                }
            }

            var recalibrate = false;
            if (processed.CanRecalibrateStandards(standard.Peptides))
            {
                using (var dlg = new MultiButtonMsgDlg(
                    TextUtil.LineSeparate(Resources.LibraryGridViewDriver_AddToLibrary_Do_you_want_to_recalibrate_the_iRT_standard_values_relative_to_the_peptides_being_added_,
                                          Resources.LibraryGridViewDriver_AddToLibrary_This_can_improve_retention_time_alignment_under_stable_chromatographic_conditions_),
                    MultiButtonMsgDlg.BUTTON_YES, MultiButtonMsgDlg.BUTTON_NO, false))
                {
                    if (dlg.ShowDialog(WizardForm) == DialogResult.Yes)
                        recalibrate = true;
                }
            }

            using (var resultsDlg = new AddIrtPeptidesDlg(processed))
            {
                if (resultsDlg.ShowDialog(this) != DialogResult.OK)
                    return;
            }

            using (var longWait = new LongWaitDlg
            {
                Text = Resources.BuildPeptideSearchLibraryControl_AddIrtLibraryTable_Adding_iRTs_to_Library
            })
            {
                try
                {
                    ImmutableList<DbIrtPeptide> newStandards = null;
                    var status = longWait.PerformWork(WizardForm, 800, monitor =>
                    {
                        if (recalibrate)
                        {
                            monitor.UpdateProgress(new ProgressStatus().ChangeSegments(0, 2));
                            newStandards = ImmutableList.ValueOf(processed.RecalibrateStandards(standard.Peptides));
                            processed = RCalcIrt.ProcessRetentionTimes(
                                monitor, processed.ProviderData.Select(data => data.Value.RetentionTimeProvider),
                                processed.ProviderData.Count, newStandards.ToArray(), new DbIrtPeptide[0]);
                        }
                        var irtDb = IrtDb.CreateIrtDb(path);
                        irtDb.AddPeptides(monitor, (newStandards ?? standard.Peptides).Concat(processed.DbIrtPeptides).ToList());
                    });
                    if (status.IsError)
                        throw status.ErrorException;
                }
                catch (Exception x)
                {
                    MessageDlg.ShowWithException(WizardForm,
                        TextUtil.LineSeparate(Resources.BuildPeptideSearchLibraryControl_AddIrtLibraryTable_An_error_occurred_trying_to_add_iRTs_to_the_library_, x.Message), x);
                }
            }
        }

        public void ForceWorkflow(ImportPeptideSearchDlg.Workflow workflowType)
        {
            WorkflowType = workflowType;
            grpWorkflow.Hide();
            var offset = grpWorkflow.Height + (lblStandardPeptides.Top - listSearchFiles.Bottom);
            listSearchFiles.Height += offset;
            lblStandardPeptides.Top += offset;
            comboStandards.Top += offset;
            cbIncludeAmbiguousMatches.Top += offset;
            cbFilterForDocumentPeptides.Top += offset;
        }

        public class InputFilesChangedEventArgs : EventArgs
        {
            public InputFilesChangedEventArgs(int numInputFiles)
            {
                NumInputFiles = numInputFiles;
            }

            public int NumInputFiles { get; private set; }
        }
    }
}
