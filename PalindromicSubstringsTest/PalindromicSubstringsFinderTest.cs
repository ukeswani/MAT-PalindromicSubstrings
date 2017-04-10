using Microsoft.VisualStudio.TestTools.UnitTesting;
using PalindromicSubstrings.AlgorithmRunners;
using PalindromicSubstrings.Algorithms;
using PalindromicSubstrings.Interfaces;
using PalindromicSubstrings.OutputFormatters;
using System.Collections.Generic;

namespace PalindromicSubstringsTest
{
    [TestClass]
    public class PalindromicSubstringsFinderTest
    {
        [TestMethod]
        public void EmptyInput_Top3_MinLength2()
        {            
            IOutputFormatter formatter = new TopXLongestPalindromesWithMinLengthY(3, 2);
            IAlgorithm algo = new ModifiedManachersAlgorithm();
            IAlgorithmRunner finder = new PalindromicSubstringsFinder(algo, formatter);

            var input = string.Empty;
            List<string> output = finder.RunOn(input);

            Assert.AreEqual(0, output.Count, "Empty list was not returned for empty input.");
        }

        [TestMethod]
        public void NoPalindrome_Top3_MinLength2()
        {
            IOutputFormatter formatter = new TopXLongestPalindromesWithMinLengthY(3, 2);
            IAlgorithm algo = new ModifiedManachersAlgorithm();
            IAlgorithmRunner finder = new PalindromicSubstringsFinder(algo, formatter);

            var input = "abcd";
            List<string> output = finder.RunOn(input);

            Assert.AreEqual(0, output.Count, "Empty list was not returned for an input with no palindromes.");
        }

        [TestMethod]
        public void Palindrome1_Top3_MinLength2()
        {
            IOutputFormatter formatter = new TopXLongestPalindromesWithMinLengthY(3, 2);
            IAlgorithm algo = new ModifiedManachersAlgorithm();
            IAlgorithmRunner finder = new PalindromicSubstringsFinder(algo, formatter);

            var input = "wacca";
            List<string> output = finder.RunOn(input);

            Assert.AreEqual(1, output.Count, "List with one palindrome was not returned for an input with one palindrome.");
            Assert.AreEqual("Text: acca, Index: 1, Length: 4", output[0], "Output string not as expected");
        }

        [TestMethod]
        public void OverlappingPalindrome_Top3_MinLength2_Expecting3()
        {
            IOutputFormatter formatter = new TopXLongestPalindromesWithMinLengthY(3, 2);
            IAlgorithm algo = new ModifiedManachersAlgorithm();
            IAlgorithmRunner finder = new PalindromicSubstringsFinder(algo, formatter);

            var input = "waccacc";
            List<string> output = finder.RunOn(input);

            Assert.AreEqual(3, output.Count, "List with 3 palindrome was not returned when top 3 requested.");
            Assert.AreEqual("Text: ccacc, Index: 2, Length: 5", output[0], "First output string not as expected");
            Assert.AreEqual("Text: acca, Index: 1, Length: 4", output[1], "Second output string not as expected");
            Assert.AreEqual("Text: cc, Index: 5, Length: 2", output[2], "Third output string not as expected");
        }

        [TestMethod]
        public void OverlappingPalindrome_Top3_MinLength6_Expecting0()
        {         
            IOutputFormatter formatter = new TopXLongestPalindromesWithMinLengthY(3, 6);
            IAlgorithm algo = new ModifiedManachersAlgorithm();
            IAlgorithmRunner finder = new PalindromicSubstringsFinder(algo, formatter);

            var input = "waccacc";
            List<string> output = finder.RunOn(input);

            Assert.AreEqual(0, output.Count, "Empty list was not returned for an input with palindromes less than 6 chars in length.");
        }

        [TestMethod]
        public void SampleInput_Top3_MinLength2()
        {
            IOutputFormatter formatter = new TopXLongestPalindromesWithMinLengthY(3, 2);
            IAlgorithm algo = new ModifiedManachersAlgorithm();
            IAlgorithmRunner finder = new PalindromicSubstringsFinder(algo, formatter);

            var input = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            List<string> output = finder.RunOn(input);

            Assert.AreEqual(3, output.Count, "List with 3 palindromes was not returned when top 3 requested.");
            Assert.AreEqual("Text: hijkllkjih, Index: 23, Length: 10", output[0], "First output string not as expected");
            Assert.AreEqual("Text: defggfed, Index: 13, Length: 8", output[1], "Second output string not as expected");
            Assert.AreEqual("Text: abccba, Index: 5, Length: 6", output[2], "Third output string not as expected");

        }

        [TestMethod]
        public void SampleInput_Top0_MinLength2()
        {
            IOutputFormatter formatter = new TopXLongestPalindromesWithMinLengthY(0, 2);
            IAlgorithm algo = new ModifiedManachersAlgorithm();
            IAlgorithmRunner finder = new PalindromicSubstringsFinder(algo, formatter);

            var input = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            List<string> output = finder.RunOn(input);

            Assert.AreEqual(0, output.Count, "Empty list was not returned when top 0 was requested.");
        }

        [TestMethod]
        public void SampleInput_Top1_MinLength2()
        {
            IOutputFormatter formatter = new TopXLongestPalindromesWithMinLengthY(1, 2);
            IAlgorithm algo = new ModifiedManachersAlgorithm();
            IAlgorithmRunner finder = new PalindromicSubstringsFinder(algo, formatter);

            var input = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            List<string> output = finder.RunOn(input);

            Assert.AreEqual(1, output.Count, "List with one palindrome was not returned when top 1 requested.");
            Assert.AreEqual("Text: hijkllkjih, Index: 23, Length: 10", output[0], "First output string not as expected");
        }

        [TestMethod]
        public void TestingUniqueness_Top3_MinLength2()
        {
            IOutputFormatter formatter = new TopXLongestPalindromesWithMinLengthY(3, 2);
            IAlgorithm algo = new ModifiedManachersAlgorithm();
            IAlgorithmRunner finder = new PalindromicSubstringsFinder(algo, formatter);

            var input = "babab";
            List<string> output = finder.RunOn(input);

            Assert.AreEqual(2, output.Count, "List with 3 palindromes was not returned when top 3 requested.");
            Assert.AreEqual("Text: babab, Index: 0, Length: 5", output[0], "First output string not as expected");
            Assert.AreEqual("Text: bab, Index: 0, Length: 3", output[1], "Second output string not as expected");
        }

        [TestMethod]
        public void SampleInput_Top3_MinLength8()
        {
            IOutputFormatter formatter = new TopXLongestPalindromesWithMinLengthY(3, 8);
            IAlgorithm algo = new ModifiedManachersAlgorithm();
            IAlgorithmRunner finder = new PalindromicSubstringsFinder(algo, formatter);

            var input = "sqrrqabccbatudefggfedvwhijkllkjihxymnnmzpop";
            List<string> output = finder.RunOn(input);

            Assert.AreEqual(2, output.Count, "List with 2 palindromes was not returned when min length 8 requested.");
            Assert.AreEqual("Text: hijkllkjih, Index: 23, Length: 10", output[0], "First output string not as expected");
            Assert.AreEqual("Text: defggfed, Index: 13, Length: 8", output[1], "Second output string not as expected");
        }       
    }   
}
