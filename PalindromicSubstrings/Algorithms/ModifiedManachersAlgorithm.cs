using PalindromicSubstrings.DataTransferObjects;
using PalindromicSubstrings.Interfaces;
using System;
using System.Collections.Generic;

namespace PalindromicSubstrings.Algorithms
{
    public class ModifiedManachersAlgorithm : IAlgorithm
    {
        public List<Substring> RunOn(string findPalindromesIn)
        {
            if (
                    String.IsNullOrEmpty(findPalindromesIn)
                    ||
                    String.IsNullOrWhiteSpace(findPalindromesIn)
                )
            {
                return new List<Substring>();
            }

            char[] inputWithBoundaries = AddBoundaries(findPalindromesIn.ToCharArray());

            int[] palindromicSpan = new int[inputWithBoundaries.Length];

            int centre = 0, rightmostCharacter = 0;
            int leftWalkingIndex = 0, rightWalkingIndex = 0;

            for (int indexCurrentCharacter = 1; indexCurrentCharacter < inputWithBoundaries.Length; indexCurrentCharacter++)
            {
                if (indexCurrentCharacter > rightmostCharacter)
                {
                    palindromicSpan[indexCurrentCharacter] = 0; leftWalkingIndex = indexCurrentCharacter - 1;
                    rightWalkingIndex = indexCurrentCharacter + 1;
                }
                else
                {
                    int currentMirroredOnCentre = centre * 2 - indexCurrentCharacter;

                    if (palindromicSpan[currentMirroredOnCentre] < (rightmostCharacter - indexCurrentCharacter - 1))
                    {
                        palindromicSpan[indexCurrentCharacter] = palindromicSpan[currentMirroredOnCentre];
                        leftWalkingIndex = -1;
                    }
                    else
                    {
                        palindromicSpan[indexCurrentCharacter] = rightmostCharacter - indexCurrentCharacter;
                        rightWalkingIndex = rightmostCharacter + 1;
                        leftWalkingIndex = indexCurrentCharacter * 2 - rightWalkingIndex;
                    }
                }

                while (
                            leftWalkingIndex >= 0
                            &&
                            rightWalkingIndex < inputWithBoundaries.Length
                            &&
                            inputWithBoundaries[leftWalkingIndex] == inputWithBoundaries[rightWalkingIndex]
                        )
                {
                    palindromicSpan[indexCurrentCharacter]++;
                    leftWalkingIndex--;
                    rightWalkingIndex++;
                }

                if ((indexCurrentCharacter + palindromicSpan[indexCurrentCharacter]) > rightmostCharacter)
                {
                    centre = indexCurrentCharacter;
                    rightmostCharacter = indexCurrentCharacter + palindromicSpan[indexCurrentCharacter];
                }
            }

            return GetPalindromes(inputWithBoundaries, palindromicSpan);
        }

        private char[] AddBoundaries(char[] input)
        {
            if (input == null || input.Length == 0)
                return "||".ToCharArray();

            char[] output = new char[input.Length * 2 + 1];

            for (int iterator = 0; iterator < (output.Length - 1); iterator = iterator + 2)
            {
                output[iterator] = '|';
                output[iterator + 1] = input[iterator / 2];
            }

            output[output.Length - 1] = '|';

            return output;
        }

        private char[] RemoveBoundaries(char[] input)
        {
            if (input == null || input.Length < 3)
                return "".ToCharArray();

            char[] output = new char[(input.Length - 1) / 2];

            for (int iterator = 0; iterator < output.Length; iterator++)
            {
                output[iterator] = input[iterator * 2 + 1];
            }
            return output;
        }

        private List<Substring> GetPalindromes(char[] inputWithBoundaries, int[] palindromicSpan)
        {            
            var output = new List<Substring>();

            for (int characterIterator = 1; characterIterator < inputWithBoundaries.Length; characterIterator++)
            {
                var span = palindromicSpan[characterIterator];

                if (span > 1)
                {
                    int palindromeCentre = characterIterator;

                    char[] substring = new char[2 * span + 1];

                    Array.Copy(inputWithBoundaries, palindromeCentre - span, substring, 0, 2 * span + 1);

                    var palindrome = new string(RemoveBoundaries(substring));
                    
                    output.Add(new Substring(palindrome, ((palindromeCentre - span) / 2)));                    
                }
            }

            return output;
        }
    }
}
