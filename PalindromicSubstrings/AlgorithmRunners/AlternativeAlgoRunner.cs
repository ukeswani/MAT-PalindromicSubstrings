using PalindromicSubstrings.DataTransferObjects;
using PalindromicSubstrings.Interfaces;
using System;
using System.Collections.Generic;

namespace PalindromicSubstrings.AlgorithmRunners
{
    public class AlternativeAlgoRunner : IAlgorithmRunner
    {
        private Func<string, List<Substring>> _algorithm;
        private Func<List<Substring>, List<string>> _formatter;

        public AlternativeAlgoRunner
                (
                     Func<string, List<Substring>> algorithm
                    , Func<List<Substring>, List<string>> formatter
                )
        {
            if (algorithm == null)
            {
                throw new ArgumentNullException("algorithm");
            }

            if (formatter == null)
            {
                throw new ArgumentNullException("formatter");
            }

            _algorithm = algorithm;
            _formatter = formatter;
        }

        public List<string> RunOn(string input)
        {
            List<string> output = new List<string>();

            try
            {
                var algoOutput = _algorithm(input);
                var formatterOutput = _formatter(algoOutput);
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
