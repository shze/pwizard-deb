﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IDPicker.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "12.0.0.0")]
    public sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"
// $Revision: 9729 $ $Date: 2016-05-19 16:42:41 -0400 (Thu, 19 May 2016) $ $Author: chambm $
//
// Licensed under the Apache License, Version 2.0 (the ""License""); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an ""AS IS"" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
//
// The Original Code is the IDPicker project.
//
// The Initial Developer of the Original Code is Matt Chambers.
//
// Copyright 2012 Vanderbilt University
//
// Contributor(s):
//
")]
        public string License {
            get {
                return ((string)(this["License"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("IDPicker.log")]
        public string LogFileName {
            get {
                return ((string)(this["LogFileName"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int DebugLevel {
            get {
                return ((int)(this["DebugLevel"]));
            }
            set {
                this["DebugLevel"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("mz5;mzML;RAW;mzXML;MGF;MS2;WIFF;d")]
        public string SourceExtensions {
            get {
                return ((string)(this["SourceExtensions"]));
            }
            set {
                this["SourceExtensions"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>&lt;RootInputDirectory&gt;</string>
  <string>&lt;RootInputDirectory&gt;\..</string>
  <string>&lt;RootInputDirectory&gt;\..\..</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection FastaPaths {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["FastaPaths"]));
            }
            set {
                this["FastaPaths"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute(@"<?xml version=""1.0"" encoding=""utf-16""?>
<ArrayOfString xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"">
  <string>&lt;RootInputDirectory&gt;</string>
  <string>&lt;RootInputDirectory&gt;\..</string>
  <string>&lt;RootInputDirectory&gt;\..\..</string>
</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection SourcePaths {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["SourcePaths"]));
            }
            set {
                this["SourcePaths"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool TopRankOnly {
            get {
                return ((bool)(this["TopRankOnly"]));
            }
            set {
                this["TopRankOnly"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::System.Collections.Specialized.StringCollection QonverterSettings {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["QonverterSettings"]));
            }
            set {
                this["QonverterSettings"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" />")]
        public global::System.Collections.Specialized.StringCollection UserLayouts {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["UserLayouts"]));
            }
            set {
                this["UserLayouts"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<ArrayOfString xmlns:xsi=\"http://www.w3." +
            "org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">\r\n  <s" +
            "tring>Comet optimized;MonteCarlo;False;Linear;Ignore;Ignore;Partition;Partition;" +
            "0.02;1 Ascending Linear comet:expect;1 Ascending Linear comet:deltacn;1 Ascendin" +
            "g Linear comet:spscore</string>\r\n  <string>Mascot ionscore;StaticWeighted;False;" +
            "Linear;Ignore;Ignore;Partition;Partition;0.02;1 Ascending Off mascot:score</stri" +
            "ng>\r\n  <string>Mascot ionscore-identityscore;StaticWeighted;False;Linear;Ignore;" +
            "Ignore;Partition;Partition;0.02;1 Ascending Off mascot:score;1 Descending Off ma" +
            "scot:identity threshold</string>\r\n  <string>MyriMatch optimized;MonteCarlo;False" +
            ";Linear;Ignore;Ignore;Partition;Partition;0.02;1 Ascending Linear myrimatch:mvh;" +
            "1 Ascending Linear xcorr</string>\r\n  <string>MyriMatch MVH;StaticWeighted;False;" +
            "Linear;Ignore;Ignore;Partition;Partition;0.02;1 Ascending Off myrimatch:mvh</str" +
            "ing>\r\n  <string>MyriMatch XCorr;StaticWeighted;False;Linear;Ignore;Ignore;Partit" +
            "ion;Partition;0.02;1 Ascending Off xcorr</string>\r\n  <string>MS-GFDB;StaticWeigh" +
            "ted;False;Linear;Ignore;Ignore;Ignore;Ignore;0.02;1 Descending Off msgfspecprob<" +
            "/string>\r\n  <string>MS-GF+;StaticWeighted;False;Linear;Ignore;Ignore;Ignore;Igno" +
            "re;0.02;1 Descending Off ms-gf:specevalue</string>\r\n  <string>OMSSA expect;Stati" +
            "cWeighted;False;Linear;Ignore;Ignore;Partition;Partition;0.02;1 Descending Off e" +
            "xpect</string>\r\n  <string>Pepitome optimized;MonteCarlo;False;Linear;Ignore;Igno" +
            "re;Partition;Partition;0.02;1 Ascending Linear hgt;1 Ascending Linear kendallpva" +
            "l</string>\r\n  <string>Pepitome MVH;StaticWeighted;False;Linear;Ignore;Ignore;Par" +
            "tition;Partition;0.02;1 Ascending Off myrimatch:mvh</string>\r\n  <string>pFind ev" +
            "alue;StaticWeighted;False;Linear;Ignore;Ignore;Partition;Partition;0.02;1 Descen" +
            "ding Off evalue</string>\r\n  <string>Phenyx zscore;StaticWeighted;False;Linear;Ig" +
            "nore;Ignore;Partition;Partition;0.02;1 Ascending Off zscore</string>\r\n  <string>" +
            "Sequest optimized;MonteCarlo;False;Linear;Ignore;Ignore;Partition;Partition;0.02" +
            ";1 Ascending Linear sequest:xcorr;1 Ascending Linear sequest:deltacn</string>\r\n " +
            " <string>Sequest XCorr;StaticWeighted;False;Linear;Ignore;Ignore;Partition;Parti" +
            "tion;0.02;1 Ascending Off sequest:xcorr</string>\r\n  <string>SpectraST optimized;" +
            "MonteCarlo;False;Linear;Ignore;Ignore;Partition;Partition;0.02;1 Ascending Linea" +
            "r dot;1 Ascending Linear delta;1 Descending Linear dot_bias</string>\r\n  <string>" +
            "TagRecon optimized;MonteCarlo;False;Linear;Ignore;Ignore;Partition;Partition;0.0" +
            "2;1 Ascending Linear myrimatch:mvh;1 Ascending Linear xcorr</string>\r\n  <string>" +
            "TagRecon MVH;StaticWeighted;False;Linear;Ignore;Ignore;Partition;Partition;0.02;" +
            "1 Ascending Off myrimatch:mvh</string>\r\n  <string>TagRecon XCorr;StaticWeighted;" +
            "False;Linear;Ignore;Ignore;Partition;Partition;0.02;1 Ascending Off xcorr</strin" +
            "g>\r\n  <string>X!Tandem optimized;MonteCarlo;False;Linear;Ignore;Ignore;Partition" +
            ";Partition;0.02;1 Descending Linear x!tandem:expect;1 Ascending Linear x!tandem:" +
            "hyperscore</string>\r\n  <string>X!Tandem expect;StaticWeighted;False;Linear;Ignor" +
            "e;Ignore;Partition;Partition;0.02;1 Descending Off x!tandem:expect</string>\r\n  <" +
            "string>X!Tandem hyperscore;StaticWeighted;False;Linear;Ignore;Ignore;Partition;P" +
            "artition;0.02;1 Ascending Off x!tandem:hyperscore</string>\r\n</ArrayOfString>")]
        public global::System.Collections.Specialized.StringCollection DefaultQonverterSettings {
            get {
                return ((global::System.Collections.Specialized.StringCollection)(this["DefaultQonverterSettings"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int DefaultMaxRank {
            get {
                return ((int)(this["DefaultMaxRank"]));
            }
            set {
                this["DefaultMaxRank"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.1")]
        public double DefaultMaxImportFDR {
            get {
                return ((double)(this["DefaultMaxImportFDR"]));
            }
            set {
                this["DefaultMaxImportFDR"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DefaultIgnoreUnmappedPeptides {
            get {
                return ((bool)(this["DefaultIgnoreUnmappedPeptides"]));
            }
            set {
                this["DefaultIgnoreUnmappedPeptides"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("0.02")]
        public double DefaultMaxFDR {
            get {
                return ((double)(this["DefaultMaxFDR"]));
            }
            set {
                this["DefaultMaxFDR"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int DefaultMinDistinctPeptides {
            get {
                return ((int)(this["DefaultMinDistinctPeptides"]));
            }
            set {
                this["DefaultMinDistinctPeptides"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("2")]
        public int DefaultMinSpectra {
            get {
                return ((int)(this["DefaultMinSpectra"]));
            }
            set {
                this["DefaultMinSpectra"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int DefaultMinAdditionalPeptides {
            get {
                return ((int)(this["DefaultMinAdditionalPeptides"]));
            }
            set {
                this["DefaultMinAdditionalPeptides"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int DefaultMinSpectraPerDistinctMatch {
            get {
                return ((int)(this["DefaultMinSpectraPerDistinctMatch"]));
            }
            set {
                this["DefaultMinSpectraPerDistinctMatch"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int DefaultMinSpectraPerDistinctPeptide {
            get {
                return ((int)(this["DefaultMinSpectraPerDistinctPeptide"]));
            }
            set {
                this["DefaultMinSpectraPerDistinctPeptide"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("10")]
        public int DefaultMaxProteinGroupsPerPeptide {
            get {
                return ((int)(this["DefaultMaxProteinGroupsPerPeptide"]));
            }
            set {
                this["DefaultMaxProteinGroupsPerPeptide"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("r-")]
        public string DefaultDecoyPrefix {
            get {
                return ((string)(this["DefaultDecoyPrefix"]));
            }
            set {
                this["DefaultDecoyPrefix"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DefaultGeneLevelFiltering {
            get {
                return ((bool)(this["DefaultGeneLevelFiltering"]));
            }
            set {
                this["DefaultGeneLevelFiltering"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool DefaultChargeIsDistinct {
            get {
                return ((bool)(this["DefaultChargeIsDistinct"]));
            }
            set {
                this["DefaultChargeIsDistinct"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("False")]
        public bool DefaultAnalysisIsDistinct {
            get {
                return ((bool)(this["DefaultAnalysisIsDistinct"]));
            }
            set {
                this["DefaultAnalysisIsDistinct"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1.0")]
        public decimal DefaultModificationRoundToNearest {
            get {
                return ((decimal)(this["DefaultModificationRoundToNearest"]));
            }
            set {
                this["DefaultModificationRoundToNearest"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("True")]
        public bool DefaultModificationsAreDistinct {
            get {
                return ((bool)(this["DefaultModificationsAreDistinct"]));
            }
            set {
                this["DefaultModificationsAreDistinct"] = value;
            }
        }
    }
}
