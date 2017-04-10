using System;

namespace PalindromicSubstrings.DataTransferObjects
{
    public class Substring
    {
        public Substring
                (
                     string value
                    , int startingIndex
                )
        {
            if (value == null)
            {
                value = String.Empty;
            }

            Value = value;
            StartingIndex = startingIndex;
        }

        public string Value
        {
            get;
            private set;
        }

        public int StartingIndex
        {
            get;
            private set;
        }
    }
}
