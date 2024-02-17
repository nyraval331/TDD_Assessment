using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_Assessment.Interface
{
    public interface INumberParser
    {
        IEnumerable<int> ParseNumbers(string input, IEnumerable<string> delimiters);
    }

}
