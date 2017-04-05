//
// $Id: ProteinListFactory.hpp 4010 2012-10-17 20:22:16Z chambm $
//
//
// Original author: Matt Chambers <matt.chambers <a.t> vanderbilt.edu>
//
// Copyright 2012 Vanderbilt University - Nashville, TN 37232
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


#ifndef _PROTEINLISTFACTORY_HPP_ 
#define _PROTEINLISTFACTORY_HPP_ 


#include "pwiz/data/proteome/ProteomeData.hpp"
#include <string>
#include <vector>


namespace pwiz {
namespace analysis {


/// Factory for instantiating and wrapping ProteinLists
class PWIZ_API_DECL ProteinListFactory
{
    public:

    /// instantiate the ProteinListWrapper indicated by wrapper
    static void wrap(proteome::ProteomeData& pd, const std::string& wrapper);

    /// instantiate a list of ProteinListWrappers
    static void wrap(proteome::ProteomeData& pd, const std::vector<std::string>& wrappers);

    /// user-friendly documentation
    static std::string usage();
};


} // namespace analysis 
} // namespace pwiz


#endif // _PROTEINLISTFACTORY_HPP_ 
