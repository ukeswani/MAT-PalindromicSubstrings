using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromicSubstrings.AlgorithmRunners;
using PalindromicSubstrings.Algorithms;
using PalindromicSubstrings.Interfaces;
using PalindromicSubstrings.OutputFormatters;
using System.Collections.Generic;

namespace PalindromicSubstringsTest
{
    [TestClass]
    public class AlternativeAlgoRunnerTest
    {
        [TestMethod]
        public void SampleInput_Top3_MinLength2_AlternativeAlgoRunner()
        {
            IOutputFormatter formatter = new TopXLongestPalindromesWithMinLengthY(3, 2);
            IAlgorithm algo = new ModifiedManachersAlgorithm();
            IAlgorithmRunner finder = new AlternativeAlgoRunner(algo.RunOn, formatter.Format);

            var input = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            List<string> output = finder.RunOn(input);

            Assert.AreEqual(3, output.Count, "List with 3 palindromes was not returned when top 3 requested.");
            Assert.AreEqual("Text: hijkllkjih, Index: 23, Length: 10", output[0], "First output string not as expected");
            Assert.AreEqual("Text: defggfed, Index: 13, Length: 8", output[1], "Second output string not as expected");
            Assert.AreEqual("Text: abccba, Index: 5, Length: 6", output[2], "Third output string not as expected");
        }
    }
}
