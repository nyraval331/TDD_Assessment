using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TDD_Assessment.Interface;

namespace TDD_Assessment.Services
{
    public class StringCalculator
    {
        private readonly IDelimiterParser _delimiterParser;
        private readonly INumberParser _numberParser;

        public StringCalculator(IDelimiterParser delimiterParser, INumberParser numberParser)
        {
            _delimiterParser = delimiterParser;
            _numberParser = numberParser;
        }

        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }

            var delimiters = _delimiterParser.GetDelimiters(numbers);
            var negativeNumbers = _numberParser.ParseNumbers(numbers, delimiters)
                .Where(n => n < 0).ToList();

            if (negativeNumbers.Any())
            {
                throw new ArgumentException("Negatives not allowed: " + string.Join(", ", negativeNumbers));
            }

            return _numberParser.ParseNumbers(numbers, delimiters).Sum();
        }
    }
}
