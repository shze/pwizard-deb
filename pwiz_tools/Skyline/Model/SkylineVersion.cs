﻿/*
 * Original author: Nicholas Shulman <nicksh .at. u.washington.edu>,
 *                  MacCoss Lab, Department of Genome Sciences, UW
 *
 * Copyright 2017 University of Washington - Seattle, WA
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
using System.Linq;
using System.Xml;
using pwiz.Skyline.Model.Results;
using pwiz.Skyline.Properties;
using pwiz.Skyline.Util;

namespace pwiz.Skyline.Model
{
    public class SkylineVersion : IComparable<SkylineVersion>
    {
        public static readonly SkylineVersion CURRENT = new SkylineVersion(() => GetCurrentVersionName(), 
            Install.ProgramNameAndVersion,
            CacheFormatVersion.CURRENT, SrmDocument.FORMAT_VERSION);
        public static readonly SkylineVersion V3_6 = new SkylineVersion(() => Resources.SkylineVersion_V3_6_Skyline_3_6, 
            "Skyline 3.6", // Not L10N
            CacheFormatVersion.Eleven, SrmDocument.FORMAT_VERSION_3_6);
        public static readonly SkylineVersion EARLIEST_SUPPORTED_SAVEAS = V3_6;

        private readonly Func<String> _getLabelFunc;
        private SkylineVersion(Func<String> getLabelFunc, String versionName, CacheFormatVersion cacheFormatVersion, double srmDocumentVersion)
        {
            _getLabelFunc = getLabelFunc;
            InvariantVersionName = versionName;
            CacheFormatVersion = cacheFormatVersion;
            SrmDocumentVersion = srmDocumentVersion;
        }

        public String Label { get { return _getLabelFunc(); } }
        public String InvariantVersionName { get; private set; }
        public double SrmDocumentVersion { get; private set; }
        public CacheFormatVersion CacheFormatVersion { get; private set; }
        public override string ToString()
        {
            return Label;
        }

        public int CompareTo(SkylineVersion other)
        {
            int result = SrmDocumentVersion.CompareTo(other.SrmDocumentVersion);
            if (result == 0)
            {
                result = CacheFormatVersion.CompareTo(other.CacheFormatVersion);
            }
            return result;
        }

        public static IList<SkylineVersion> SupportedForSharing()
        {
            List<SkylineVersion> versions = new List<SkylineVersion> { V3_6 };
            if (CURRENT.CompareTo(versions.First()) != 0)
            {
                versions.Insert(0, CURRENT);
            }
            return versions;
        }

        public static String GetCurrentVersionName()
        {
            String labelFormat = Resources.SkylineVersion_GetCurrentVersionName_Current___0__;

            if (Install.Type == Install.InstallType.developer)
            {
                return string.Format(labelFormat, Resources.SkylineVersion_GetCurrentVersionName_Developer_Build);
            }
            return string.Format(labelFormat, Install.ProgramNameAndVersion);
        }

        public static SkylineVersion FromXmlWriter(XmlWriter xmlWriter)
        {
            var skylineVersionContainer = xmlWriter as ISkylineVersionContainer;
            if (skylineVersionContainer == null)
            {
                return CURRENT;
            }
            return skylineVersionContainer.GetSkylineVersion();
        }
    }

    public interface ISkylineVersionContainer
    {
        SkylineVersion GetSkylineVersion();
    }
}
