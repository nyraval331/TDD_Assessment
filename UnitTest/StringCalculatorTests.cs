using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using TDD_Assessment.Interface;
using TDD_Assessment.Services;

namespace TDD_Assessment.UnitTest
{
    [TestClass]
    public class StringCalculatorTests
    {
        [TestMethod]
        public void Add_EmptyString_ReturnsZero()
        {
            // Arrange
            var delimiterParserMock = new Mock<IDelimiterParser>();
            var numberParserMock = new Mock<INumberParser>();
            var calculator = new StringCalculator(delimiterParserMock.Object, numberParserMock.Object);

            // Act
            int result = calculator.Add("");

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void Add_SingleNumber_ReturnsNumber()
        {
            // Arrange
            var delimiterParserMock = new Mock<IDelimiterParser>();
            var numberParserMock = new Mock<INumberParser>();
            var calculator = new StringCalculator(delimiterParserMock.Object, numberParserMock.Object);

            // Act
            int result = calculator.Add("5");

            // Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            var delimiterParserMock = new Mock<IDelimiterParser>();
            var numberParserMock = new Mock<INumberParser>();
            numberParserMock.Setup(parser => parser.ParseNumbers("1,2", It.IsAny<string[]>()))
                           .Returns(new[] { 1, 2 });

            var calculator = new StringCalculator(delimiterParserMock.Object, numberParserMock.Object);

            // Act
            int result = calculator.Add("1,2");

            // Assert
            Assert.AreEqual(3, result);
        }

        [TestMethod]
        public void Add_NegativeNumbers_ThrowsException()
        {
            // Arrange
            var delimiterParserMock = new Mock<IDelimiterParser>();
            var numberParserMock = new Mock<INumberParser>();
            numberParserMock.Setup(parser => parser.ParseNumbers("-1,-2", It.IsAny<string[]>()))
                           .Returns(new[] { -1, -2 });

            var calculator = new StringCalculator(delimiterParserMock.Object, numberParserMock.Object);

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() => calculator.Add("-1,-2"));
        }
    }
}
