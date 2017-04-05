//
// $Id: SpectrumList_IonMobility.hpp 10494 2017-02-21 16:53:20Z pcbrefugee $
//
//
// Original author: Matt Chambers <matt.chambers <a.t> vanderbilt.edu>
//
// Copyright 2016 Vanderbilt University - Nashville, TN 37232
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


#ifndef _SPECTRUMLIST_IONMOBILITY_HPP_ 
#define _SPECTRUMLIST_IONMOBILITY_HPP_ 


#include "pwiz/utility/misc/Export.hpp"
#include "pwiz/data/msdata/SpectrumListWrapper.hpp"

namespace pwiz {
namespace analysis {

/// SpectrumList implementation that provides access to vendor-specific ion mobility functions
class PWIZ_API_DECL SpectrumList_IonMobility : public msdata::SpectrumListWrapper
{
    public:

    SpectrumList_IonMobility(const msdata::SpectrumListPtr& inner);

    static bool accept(const msdata::SpectrumListPtr& inner);
    virtual msdata::SpectrumPtr spectrum(size_t index, bool getBinaryData = false) const;

    /// returns true if file in question contains necessary information for CCS/DT handling
    virtual bool canConvertDriftTimeAndCCS() const;

    /// returns collisional cross-section associated with the drift time (specified in milliseconds)
    virtual double driftTimeToCCS(double driftTime, double mz, int charge) const;

    /// returns the drift time (in milliseconds) associated with the given collisional cross-section
    virtual double ccsToDriftTime(double ccs, double mz, int charge) const;

    private:
    int mode_;
};


} // namespace analysis 
} // namespace pwiz


#endif // _SPECTRUMLIST_IONMOBILITY_HPP_ 
