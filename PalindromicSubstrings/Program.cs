using PalindromicSubstrings.AlgorithmRunners;
using PalindromicSubstrings.Algorithms;
using PalindromicSubstrings.Interfaces;
using PalindromicSubstrings.OutputFormatters;
using System;
using System.Collections.Generic;

namespace PalindromicSubstrings
{
    class Program
    {
        static void Main(string[] args)
        {
            IOutputFormatter formatter = new TopXLongestPalindromesWithMinLengthY(3, 2);
            IAlgorithm algo = new ModifiedManachersAlgorithm();
            IAlgorithmRunner finder = new PalindromicSubstringsFinder(algo, formatter);

            ConsoleKeyInfo instruction;

            do
            {
                Console.Write("\n\nInput String: ");
                var input = Console.ReadLine();

                Console.WriteLine("\nOutput:");

                List<string> output = finder.RunOn(input);

                Console.WriteLine("{0} palindromic substrings.",output.Count );

                foreach (var substring in output)
                {
                    Console.WriteLine("-> {0}", substring);
                }

                Console.Write("\n\n'E' or 'e' to Exit. Any other key to continue. ");
                instruction = Console.ReadKey();               

            } while (!(instruction.KeyChar == 'e' || instruction.KeyChar == 'E'));


        }
    }
}
