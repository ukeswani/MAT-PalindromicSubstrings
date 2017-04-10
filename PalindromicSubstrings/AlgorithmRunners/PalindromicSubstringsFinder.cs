using PalindromicSubstrings.Interfaces;
using System;
using System.Collections.Generic;

namespace PalindromicSubstrings.AlgorithmRunners
{
    public class PalindromicSubstringsFinder : IAlgorithmRunner
    {
        private IAlgorithm _algorithm;
        private IOutputFormatter _formatter;

        public PalindromicSubstringsFinder
                (
                     IAlgorithm algorithm
                    ,IOutputFormatter formatter
                )
        {
            _algorithm = algorithm;
            _formatter = formatter;
        }

        public List<string> RunOn(string input)
        {
            List<string> output = new List<string>();

            try
            {
                var algoOutput = _algorithm.RunOn(input);
                var formatterOutput = _formatter.Format(algoOutput);
                output = formatterOutput;
            }
            catch (Exception e)
            {
                Console.WriteLine("Input: {0}. Error Message [{1}].", input, e.Message);
            }

            return output;
        }
    }
}
