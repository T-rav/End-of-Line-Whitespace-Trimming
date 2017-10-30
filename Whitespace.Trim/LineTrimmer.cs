using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Whitespace.Trim
{
    public class LineTrimmer
    {
        public string TrimEndOfLine(string input)
        {
            var tokens = CreateTokens(input);
            var result = new StringBuilder();

            foreach (var token in tokens)
            {
                var processedToken = RemoveTrailingWhitespace(token);
                result.Append(processedToken);
            }
            
            return result.ToString();
        }

        private string RemoveTrailingWhitespace(string token)
        {
            return IsNewLineToken(token) ? ReturnTokenAsSent(token) : TrimTrailingWhitespace(token);
        }

        private string ReturnTokenAsSent(string part)
        {
            return part;
        }

        private string TrimTrailingWhitespace(string token)
        {
            return token.TrimEnd();
        }

        private bool IsNewLineToken(string token)
        {
            return token == "\r\n" || token == "\n";
        }

        private IEnumerable<string> CreateTokens(string input)
        {
            var parts = Regex.Split(input, "(\r\n)|(\n)");
            return parts;
        }
    }
}