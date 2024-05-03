using System;
using System.Collections.Generic;
using System.Linq;

namespace DiffPatch.Core
{
    public static class StringHelper
    {
        public static string[] SplitLines(string? input, string lineEnding)
        {
            if (string.IsNullOrWhiteSpace(input))
                return Array.Empty<string>();
            
            string[] lines = input!.Split([lineEnding], StringSplitOptions.None);
            return lines.Length == 0 ? Array.Empty<string>() : lines;
        }
    }
}
