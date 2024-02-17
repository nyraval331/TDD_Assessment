using System;
using System.Collections.Generic;
using System.Linq;
using TDD_Assessment.Interface;

namespace TDD_Assessment.Services
{
    public class NumberParser : INumberParser
    {
        public IEnumerable<int> ParseNumbers(string input, IEnumerable<string> delimiters)
        {
            return input.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                       .Select(s => int.Parse(s))
                       .Where(n => n <= 1000);
        }
    }
}
