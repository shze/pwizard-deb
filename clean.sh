#!/bin/bash

pwiz_root=$(dirname $0)
pushd $pwiz_root > /dev/null

echo "Cleaning project..."
if (ls build-*-* > /dev/null 2>&1); then rm -fr build-*-*; fi;
if (ls libraries/boost_*_*_? > /dev/null 2>&1); then rm -fr libraries/boost_*_*_?; fi;
if [ -d libraries/boost-build/engine/bin ]; then rm -fr libraries/boost-build/engine/bin; fi;
if [ -d libraries/boost-build/engine/bootstrap ]; then rm -fr libraries/boost-build/engine/bootstrap; fi;
if [ -d libraries/gd-2.0.33 ]; then rm -fr libraries/gd-2.0.33; fi;
if [ -d libraries/zlib-1.2.3 ]; then rm -fr libraries/zlib-1.2.3; fi;
if [ -d libraries/libgd-2.1.0alpha ]; then rm -fr libraries/libgd-2.1.0alpha; fi;
if [ -d libraries/libpng-1.5.6 ]; then rm -fr libraries/libpng-1.5.6; fi;
if [ -d libraries/freetype-2.4.7 ]; then rm -fr libraries/freetype-2.4.7; fi;
if [ -d libraries/hdf5-1.8.7 ]; then rm -fr libraries/hdf5-1.8.7; fi;
if [ -d libraries/fftw-3.1.2 ]; then rm -fr libraries/fftw-3.1.2; fi;
if [ -d libraries/expat-2.0.1 ]; then rm -fr libraries/expat-2.0.1; fi;
if [ -f libraries/libfftw3-3.def ]; then rm -f libraries/libfftw3-3.def; fi;
if [ -f libraries/libfftw3-3.dll ]; then rm -f libraries/libfftw3-3.dll; fi;

if [ -d check/ ]; then rm -fr check/; fi;

if [ -f pwiz/Version.cpp ]; then rm -f pwiz/Version.cpp; fi;
if [ -f pwiz/data/msdata/Version.cpp ]; then rm -f pwiz/data/msdata/Version.cpp; fi;
if [ -f pwiz/data/tradata/Version.cpp ]; then rm -f pwiz/data/tradata/Version.cpp; fi;
if [ -f pwiz/data/identdata/Version.cpp ]; then rm -f pwiz/data/identdata/Version.cpp; fi;
if [ -f pwiz/data/proteome/Version.cpp ]; then rm -f pwiz/data/proteome/Version.cpp; fi;
if [ -f pwiz/analysis/Version.cpp ]; then rm -f pwiz/analysis/Version.cpp; fi;
if [ -f pwiz/analysis/spectrum_processing/SpectrumList_MZRefinerTest.data/JD_06232014_sample4_C.mzRefinement.tsv ]; then rm -f pwiz/analysis/spectrum_processing/SpectrumList_MZRefinerTest.data/JD_06232014_sample4_C.mzRefinement.tsv; fi;

if [ -d pwiz/data/vendor_readers/Thermo/Reader_Thermo_Test.data ]; then rm -fr pwiz/data/vendor_readers/Thermo/Reader_Thermo_Test.data; fi;
if [ -d pwiz/data/vendor_readers/Agilent/Reader_Agilent_Test.data ]; then rm -fr pwiz/data/vendor_readers/Agilent/Reader_Agilent_Test.data; fi;
if [ -d pwiz/data/vendor_readers/ABI/Reader_ABI_Test.data ]; then rm -fr pwiz/data/vendor_readers/ABI/Reader_ABI_Test.data; fi;
if [ -d pwiz/data/vendor_readers/ABI/T2D/Reader_ABI_T2D_Test.data ]; then rm -fr pwiz/data/vendor_readers/ABI/T2D/Reader_ABI_T2D_Test.data; fi;
if [ -d pwiz/data/vendor_readers/Waters/Reader_Waters_Test.data ]; then rm -fr pwiz/data/vendor_readers/Waters/Reader_Waters_Test.data; fi;
if [ -d pwiz/data/vendor_readers/Bruker/Reader_Bruker_Test.data ]; then rm -fr pwiz/data/vendor_readers/Bruker/Reader_Bruker_Test.data; fi;
if [ -d pwiz/data/vendor_readers/UIMF/Reader_UIMF_Test.data ]; then rm -fr pwiz/data/vendor_readers/UIMF/Reader_UIMF_Test.data; fi;

if [ -d pwiz_tools/BiblioSpec/tests/inputs ]; then rm -fr pwiz_tools/BiblioSpec/tests/inputs; fi;
if [ -d pwiz_tools/BiblioSpec/tests/output ]; then rm -fr pwiz_tools/BiblioSpec/tests/output; fi;

if [ -f pwiz_tools/Bumbershoot/directag/directagVersion.cpp ]; then rm -f pwiz_tools/Bumbershoot/directag/directagVersion.cpp; fi;
if [ -f pwiz_tools/Bumbershoot/freicore/svnrev.hpp ]; then rm -f pwiz_tools/Bumbershoot/freicore/svnrev.hpp; fi;
if [ -f pwiz_tools/Bumbershoot/greazy/greazyVersion.cpp ]; then rm -f pwiz_tools/Bumbershoot/greazy/greazyVersion.cpp; fi;
if [ -f pwiz_tools/Bumbershoot/myrimatch/myrimatchVersion.cpp ]; then rm -f pwiz_tools/Bumbershoot/myrimatch/myrimatchVersion.cpp; fi;
if [ -f pwiz_tools/Bumbershoot/pepitome/pepitomeVersion.cpp ]; then rm -f pwiz_tools/Bumbershoot/pepitome/pepitomeVersion.cpp; fi;
if [ -f pwiz_tools/Bumbershoot/quameter/quameterVersion.cpp ]; then rm -f pwiz_tools/Bumbershoot/quameter/quameterVersion.cpp; fi;
if [ -f pwiz_tools/Bumbershoot/tagrecon/tagreconVersion.cpp ]; then rm -f pwiz_tools/Bumbershoot/tagrecon/tagreconVersion.cpp; fi;

popd > /dev/null
