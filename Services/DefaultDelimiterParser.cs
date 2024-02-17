using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using TDD_Assessment.Interface;

namespace TDD_Assessment.Services
{
    public class DefaultDelimiterParser : IDelimiterParser
    {
        private readonly char[] defaultDelimiters = { ',', '\n' };

        public IEnumerable<string> GetDelimiters(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return defaultDelimiters.Select(c => c.ToString());
            }

            var match = Regex.Match(input, @"^//\[(?<delimiter>[^\]]+)\]\n");
            return match.Success
                ? new[] { match.Groups["delimiter"].Value }
                    .Concat(defaultDelimiters.Select(c => c.ToString()))
                : defaultDelimiters.Select(c => c.ToString());
        }
    }

}
