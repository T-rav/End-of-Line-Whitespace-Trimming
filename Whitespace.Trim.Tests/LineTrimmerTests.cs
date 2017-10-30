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
        public void TrimEndOfLine_WhenNoWhitespacePresent_ShouldReturnInput(string input)
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
        public void TrimEndOfLine_WhenLeadingWhitespacePresent_ShouldReturnInput(string input)
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
        [TestCase("try\r\n", "try\r\n")]
        [TestCase("nigh\n", "nigh\n")]
        public void TrimEndOfLine_WhenTrailingWhitespacePresent_ShouldReturnTrimmedInput(string input, string expected)
        {
            //---------------Arrange------------------
            var sut = new LineTrimmer();
            //---------------Act----------------------
            var actual = sut.TrimEndOfLine(input);
            //---------------Assert-------------------
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TrimEndOfLine_WhenMultilineWithWhitespaceAtEndOfEachLine_ShouldReturnWithEachLineTrimmed()
        {
            //---------------Arrange------------------
            var input = "ab \r\ncd \r\nef\t\ngh \nzz    ";
            var expectd = "ab\r\ncd\r\nef\ngh\nzz";
            var sut = new LineTrimmer();
            //---------------Act----------------------
            var actual = sut.TrimEndOfLine(input);
            //---------------Assert-------------------
            Assert.AreEqual(expectd, actual);
        }
    }
}
