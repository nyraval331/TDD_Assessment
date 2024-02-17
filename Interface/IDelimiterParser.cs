using System;
using System.Collections.Generic;
using System.Text;

namespace TDD_Assessment.Interface
{
    public interface IDelimiterParser
    {
        IEnumerable<string> GetDelimiters(string input);
    }
}
