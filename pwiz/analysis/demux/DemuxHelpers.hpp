//
// $Id: DemuxHelpers.hpp 10348 2017-01-11 18:26:26Z chambm $
//
//
// Original author: Austin Keller <atkeller .@. uw.edu>
//
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License.
//

// Note: The following Doxygen comment is required in order to have global functions, variables, etc. parsed.
/** \file DemuxHelpers.hpp
* Helper functions for demultiplexing
* Helper functions include nice methods of accessing CV parameters and other generally useful functions.
*/

#ifndef _DEMUXHELPERS_HPP
#define _DEMUXHELPERS_HPP

#include "DemuxTypes.hpp"
#include "EnumConstantNotPresentException.hpp"
#include <boost/tokenizer.hpp>
#include "pwiz/utility/chemistry/MZTolerance.hpp"

namespace pwiz
{
namespace analysis
{
    /**
    * Converts an enum to it's corresponding string in a prebuilt map. Exception is thrown if map does not contain enum.
    * @param[in] e The enum
    * @param[out] m The map pairing each enum to a string
    * @return Returns the string from the map
    */
    template <typename T>
    const std::string& enumToString(T e, std::map<T, std::string> m)
    {
        return m.at(e);
    }

    /**
    * Converts a string to it's corresponding enum in a prebuilt map. Exception is thrown if map does not contain string.
    * @param[in] s The string
    * @param[out] m The map pairing each enum to a string
    * @return Returns the enum from the map
    */
    template<typename T>
    T stringToEnum(const std::string& s, std::map<T, std::string> m)
    {
        for (auto it = m.begin(); it != m.end(); ++it) {
            if (it->second.compare(s) == 0)
                return it->first;
        }
        throw EnumConstantNotPresentException("Given string doesn't correspond to an enum");
    }

    /// Tool for pulling each scan id attribute and its value from a scan id.
    /// Scan ids contain sets of attribute-value pairs. Each pair is separated from others by a space. Each attribute is separated from its
    /// value by an "=". E.g. "attribute1=value1 attribute2=value2 attribute3=value3"
    typedef boost::tokenizer<boost::char_separator<char> > ScanIdTokenizer;

    /**
    * Tries to read the given token from a spectrum identity id. The spectrum identity id is a set of pairs of attribute names (tokens) and their
    * corresponding values.
    * @param[in] spectrumIdentity The SpectrumIdentity to search
    * @param[in] tokenName attribute
    * @param[out] value value
    * @return false if the given token does not exist in the SpectrumIdentity id
    */
    bool TryGetScanIDToken(const msdata::SpectrumIdentity& spectrumIdentity, const std::string& tokenName, std::string& value);

    /**
    * Tries to read the index of the demultiplexed spectrum relative to the multiplexed spectrum it was derived from.
    * For example, if a multiplexed spectrum is split into 3 demultiplexed spectra, the resulting spectra will have indices 0, 1, and 2.
    * @param[in] spectrumIdentity The SpectrumIdentity to search
    * @param[out] index The demux index of the spectrum
    * @return false if the given SpectrumIdentity does not contain information about the scan index. E.g., if the given spectrum is not a
    *         demultiplexed spectrum.
    */
    bool TryGetDemuxIndex(const msdata::SpectrumIdentity& spectrumIdentity, size_t& index);

    /**
    * Tries to read the original index of the spectrum before demultiplexing using the SpectrumIdentity of a (demultiplexed) spectrum.
    * Demultiplexing effectively splits each spectrum into multiple demultiplexed spectra. This method allows for retrieval of the original
    * spectrum before this split.
    * @param[in] spectrumIdentity The SpectrumIdentity to search
    * @param[out] index The original index of the spectrum
    * @return false if the given SpectrumIdentity does not contain information about the scan index
    */
    bool TryGetOriginalIndex(const msdata::SpectrumIdentity& spectrumIdentity, size_t& index);

    /**
    * Tries to read MS level from spectrum
    * @param[in] spectrum The mass spectrum to read
    * @param[out] msLevel The number of sequential MS analyses (e.g. MS = 1, MS/MS = 2)
    * @return true if successful, false otherwise
    */
    bool TryGetMSLevel(const msdata::Spectrum& spectrum, int& msLevel);

    /**
    * Tries to get the number of precursors contributing to a multiplexed spectrum.
    * This is only well defined for spectra of MS2 or greater. (Note: only parsing of MS2 is implemented currently)
    * @param[in] spectrum The mass spectrum to read
    * @param[out] numPrecursors The number of precursor windows contributing to the given mass spectrum
    * @return true if successful, false otherwise
    */
    bool TryGetNumPrecursors(const msdata::Spectrum& spectrum, int& numPrecursors);

    /**
    * Tries to get the start time of the scan
    * @param[in] spectrum The mass spectrum to read
    * @param[out] startTime The start time of the scan (may also be interpreted as retention time)
    * @return true if successful, false otherwise
    */
    bool TryGetStartTime(const msdata::Spectrum& spectrum, double& startTime);

    /**
    * Tries to find a given number of ms2 spectra near the given spectrum index.
    * This handles edge cases near the beginning and end of the SpectrumList and tries to distribute the spectra surrounding the centerIndex
    * as evenly as possible. Throws std::out_of_range exception if center index is not in range of SpectrumList.
    * @param[out] spectraIndices The indices to the nearby spectra.
    * @param[in] slPtr The spectrum list to search
    * @param[in] centerIndex Index of spectrum in the given SpectrumList around which to search
    * @param[in] numSpectraToFind Number of spectra to find
    * @param[in] stride Number of ms2 spectra to step through to find a nearby spectrum. E.g. a stride of 2 would skip every other ms2 spectrum. This will still return
                          the chosen total number of spectra. This is useful when ms2 spectra are collected cyclically and only a single index within that cycle is desired.
    * @return false if not enough spectra can be found
    */
    bool FindNearbySpectra(std::vector<size_t>& spectraIndices, pwiz::msdata::SpectrumList_const_ptr slPtr, size_t centerIndex,
                           size_t numSpectraToFind, size_t stride = 1);
} // namespace analysis
} // namespace pwiz
#endif // _DEMUXHELPERS_HPP