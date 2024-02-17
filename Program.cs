using System;
using TDD_Assessment.Interface;
using TDD_Assessment.Services;

namespace TDD_Assessment
{
    public class Program
    {
        static void Main(string[] args)
        {
            IDelimiterParser delimiterParser = new DefaultDelimiterParser();
            INumberParser numberParser = new NumberParser();

            StringCalculator stringCalculator = new StringCalculator(delimiterParser, numberParser);

            Console.Write("Enter numbers separated by commas: ");
            string inputNumbers = Console.ReadLine();

            int result = stringCalculator.Add(inputNumbers);

            // Display the result
            Console.WriteLine("Result: " + result);
        }
    }
}
