using System;
using NUnit.Framework;

namespace Whitespace.Trim.Tests
{
    [TestFixture]
    public class LineTrimmerTests
    {
        [TestCase("")]
        [TestCase("abc")]
        [TestCase("\r\n")]
        [TestCase("\n")]
        public void Trim_WhenNoWhitespacePresent_ShouldReturnInput(string input)
        {
            //---------------Arrange------------------
            var sut = new LineTrimmer();
            //---------------Act----------------------
            var actual = sut.TrimEndOfLine(input);
            //---------------Assert-------------------
            Assert.AreEqual(input, actual);
        }

        [TestCase(" a")]
        [TestCase(" xyz")]
        [TestCase("\txyz")]
        [TestCase("    xyz")]
        [TestCase("\nxyz")]
        [TestCase("\r\nxyz")]
        public void Trim_WhenLeadingWhitespacePresent_ShouldReturnInput(string input)
        {
            //---------------Arrange------------------
            var sut = new LineTrimmer();
            //---------------Act----------------------
            var actual = sut.TrimEndOfLine(input);
            //---------------Assert-------------------
            Assert.AreEqual(input, actual);
        }

        [TestCase("z\t","z")]
        [TestCase("qvb ", "qvb")]
        public void Trim_WhenTrailingWhitespacePresent_ShouldReturnTrimmedInput(string input, string expected)
        {
            //---------------Arrange------------------
            var sut = new LineTrimmer();
            //---------------Act----------------------
            var actual = sut.TrimEndOfLine(input);
            //---------------Assert-------------------
            Assert.AreEqual(expected, actual);
        }
    }

    public class LineTrimmer
    {
        public string TrimEndOfLine(string input)
        {
            if (input == "\r\n" || input == "\n")
            {
                return input;
            }

            return input.TrimEnd();
        }
    }
}
