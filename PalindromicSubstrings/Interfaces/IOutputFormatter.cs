using PalindromicSubstrings.DataTransferObjects;
using System.Collections.Generic;

namespace PalindromicSubstrings.Interfaces
{
    public interface IOutputFormatter
    {
        List<string> Format(List<Substring> toBeFormatted);
    }
}
