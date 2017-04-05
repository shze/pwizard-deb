/*
 * Original author: Brendan MacLean <brendanx .at. u.washington.edu>,
 *                  MacCoss Lab, Department of Genome Sciences, UW
 *
 * Copyright 2011 University of Washington - Seattle, WA
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using pwiz.Common.Chemistry;
using pwiz.Skyline.Model;
using pwiz.Skyline.Util;
using pwiz.SkylineTestUtil;

namespace pwiz.SkylineTestA
{
    /// <summary>
    /// Unit tests of mass calculation
    /// </summary>
    [TestClass]
    public class MassCalcTest : AbstractUnitTest
    {
        /// <summary>
        /// Test the masses in the <see cref="BioMassCalc.DEFAULT_ABUNDANCES"/> object to make
        /// sure they match the base symbol mass values in <see cref="BioMassCalc"/>.
        /// </summary>
        [TestMethod]
        public void BioMassCalcAbundanceMassesTest()
        {
            foreach (var atomAbundance in BioMassCalc.DEFAULT_ABUNDANCES)
            {
                string symbol = atomAbundance.Key;
                var massDistOrdered = atomAbundance.Value.MassesSortedByAbundance();
                TestMass(symbol, massDistOrdered, 0);
                TestMass(symbol + "'", massDistOrdered, 1);
                TestMass(symbol + "\"", massDistOrdered, 2);
            }
        }

        /// <summary>
        /// Test that the mass at a specific index in a mass distribution matches the expected
        /// mass for the symbol in the <see cref="BioMassCalc.MONOISOTOPIC"/> mass calculator.
        /// </summary>
        /// <param name="symbol">Symbol for the atom</param>
        /// <param name="massDistOrdered">Mass distribution to test</param>
        /// <param name="indexMass">Index of the mass to test within the mass distribution</param>
        private static void TestMass(string symbol, IList<KeyValuePair<double, double>> massDistOrdered, int indexMass)
        {
            double massExpected = BioMassCalc.MONOISOTOPIC.GetMass(symbol);
            if (massExpected != 0)
            {
                double massActual = massDistOrdered[indexMass].Key;
                Assert.AreEqual(massExpected, massActual,
                    string.Format("The mass for {0} was expected to be {1} but was found to be {2}", symbol, massExpected, massActual));
            }
        }

        [TestMethod]
        public void SequenceMassCalcTest()
        {
            // Test case that caused unexpected exception when O- was not parsed correctly.
            SequenceMassCalc.ParseModCounts(BioMassCalc.MONOISOTOPIC, "OO-HNHN", new Dictionary<string, int>());            
            
            // Test normal function
            var sequence = "VEDELK";
            var calc = new SequenceMassCalc(MassType.Monoisotopic);
            var expected = new List<KeyValuePair<double, double>>
            {
                new KeyValuePair<double, double>(366.69232575, 0.668595429107379),
                new KeyValuePair<double, double>(367.194009631186, 0.230439133647163),
                new KeyValuePair<double, double>(367.69569373213, 0.0384590257505838),
                new KeyValuePair<double, double>(367.694446060561, 0.017949871952498),
                new KeyValuePair<double, double>(367.19084355, 0.017192511410608),
                new KeyValuePair<double, double>(368.196128166749, 0.00616111554527541),
                new KeyValuePair<double, double>(367.692527431186, 0.00592559754703795),
                new KeyValuePair<double, double>(367.1954645, 0.00513890101333714),
                new KeyValuePair<double, double>(368.197384928765, 0.00425230800778248),
                new KeyValuePair<double, double>(367.697148381186, 0.00177118156340514),
                new KeyValuePair<double, double>(368.697813900475, 0.00101646716687999),
                new KeyValuePair<double, double>(368.19421153213, 0.00098894968507418),
                new KeyValuePair<double, double>(368.1929673, 0.000458171690211896),
                new KeyValuePair<double, double>(368.699089317816, 0.000360958912487784),
                new KeyValuePair<double, double>(368.19883248213, 0.000295600474962106),
                new KeyValuePair<double, double>(368.69657325, 0.000202295887934749),
                new KeyValuePair<double, double>(367.68936135, 0.000189469126984509),
                new KeyValuePair<double, double>(368.694649407319, 0.000157258059028779),
                new KeyValuePair<double, double>(369.199499540822, 0.000109802223366965),
                new KeyValuePair<double, double>(368.695902738459, 0.000109341412261551),
                new KeyValuePair<double, double>(369.198241127809, 7.04324061939316E-05),
                new KeyValuePair<double, double>(368.191045231186, 6.53027220564238E-05),
                new KeyValuePair<double, double>(368.700518794653, 3.19123118597943E-05),
                new KeyValuePair<double, double>(369.19633171026, 2.61321131972594E-05),
                new KeyValuePair<double, double>(369.699928636691, 1.13012567237636E-05),
                new KeyValuePair<double, double>(368.69272933213, 1.08986656450318E-05),
                new KeyValuePair<double, double>(367.69860325, 1.06303400612337E-05),
            };
            var actual = calc.GetMzDistribution(sequence, 2, IsotopeAbundances.Default).MassesSortedByAbundance();
            for (var i = 0; i < expected.Count; i++)
            {
                Assert.AreEqual(expected[i].Key, actual[i].Key, .0001);
                Assert.AreEqual(expected[i].Value, actual[i].Value, .0001);
            } 
        }

        [TestMethod]
        public void TestSequenceMassCalcNormalizeModifiedSequence()
        {
            const string normalizedModifiedSequence = "ASDF[+6.0]GHIJ";
            Assert.AreEqual(normalizedModifiedSequence, SequenceMassCalc.NormalizeModifiedSequence("ASDF[6]GHIJ"));
            Assert.AreEqual(normalizedModifiedSequence, SequenceMassCalc.NormalizeModifiedSequence("ASDF[+6]GHIJ"));
            Assert.AreEqual(normalizedModifiedSequence, SequenceMassCalc.NormalizeModifiedSequence("ASDF[+6.000123]GHIJ"));
            Assert.AreSame(normalizedModifiedSequence, SequenceMassCalc.NormalizeModifiedSequence(normalizedModifiedSequence));

            Assert.AreEqual("ASDF[-6.0]GHIJ", SequenceMassCalc.NormalizeModifiedSequence("ASDF[-6]GHIJ"));

            AssertEx.ThrowsException<ArgumentException>(() => SequenceMassCalc.NormalizeModifiedSequence("ASC[Carbomidomethyl C]FGHIJ"));
            AssertEx.ThrowsException<ArgumentException>(() => SequenceMassCalc.NormalizeModifiedSequence("ASC[6"));
        }
    }
}