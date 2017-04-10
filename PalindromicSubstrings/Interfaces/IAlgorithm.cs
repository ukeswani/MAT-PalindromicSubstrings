using PalindromicSubstrings.DataTransferObjects;
using System.Collections.Generic;

namespace PalindromicSubstrings.Interfaces
{
    public interface IAlgorithm
    {
        List<Substring> RunOn(string findPalindromesIn);
    }
}
