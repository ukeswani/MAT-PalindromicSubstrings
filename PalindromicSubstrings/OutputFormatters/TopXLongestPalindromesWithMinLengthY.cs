using PalindromicSubstrings.DataTransferObjects;
using PalindromicSubstrings.Interfaces;
using System;
using System.Collections.Generic;

namespace PalindromicSubstrings.OutputFormatters
{
    public class TopXLongestPalindromesWithMinLengthY : IOutputFormatter
    {
        private int _substringsToReturn;
        private int _minimumLength;

        public TopXLongestPalindromesWithMinLengthY
                (
                     int substringsToReturn
                    , int minimumLength
                )
        {
            _substringsToReturn = substringsToReturn;
            _minimumLength = minimumLength;
        }

        public List<string> Format(List<Substring> toBeFormatted)
        {
            if (
                    toBeFormatted == null
                    ||
                    toBeFormatted.Count == 0
                )
            {
                return new List<string>();
            }
                                    
            List<Substring> formatted = new List<Substring>();

            foreach (var substring in toBeFormatted)
            {
                if(!formatted.Exists((a) => a.Value.Equals(substring.Value)))
                {
                    formatted.Add(substring);
                }
            }           

            formatted.Sort((a, b) => b.Value.Length.CompareTo(a.Value.Length));

            formatted = formatted.FindAll((a) => a.Value.Length >= _minimumLength);

            if (formatted.Count > _substringsToReturn)
            {
                formatted = formatted.GetRange(0, _substringsToReturn);
            }

            return formatted.ConvertAll
                                (
                                    (a) => String.Format
                                                    (
                                                         "Text: {0}, Index: {1}, Length: {2}"
                                                        , a.Value
                                                        , a.StartingIndex
                                                        , a.Value.Length
                                                    )
                                );
        }
    }
}
