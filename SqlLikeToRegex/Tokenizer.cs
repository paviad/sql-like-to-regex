using System.Text.RegularExpressions;

namespace SqlLikeToRegex;

public class Tokenizer {
    private readonly List<TokenDescriptor> _patterns = new();

    public Tokenizer Add(string regex, Func<string, Token> creator) {
        _patterns.Add(new TokenDescriptor(new Regex(regex), creator));
        return this;
    }

    public List<Token> Tokenize(string clause) {
        List<Token> tokens = new();
        var copy = clause;

        var position = 0;
        while (copy != "") {
            var found = false;
            foreach (var (pattern, fn) in _patterns) {
                var m = pattern.Match(copy);
                if (m.Success) {
                    found = true;
                    var token = m.Groups[0].Value;
                    tokens.Add(fn(token));
                    copy = pattern.Replace(copy, "", 1);
                    position += token.Length;
                    break;
                }
            }

            if (!found) {
                throw new ParseException("Unexpected sequence found in input string.", ++position);
            }
        }

        return tokens;
    }

    private record TokenDescriptor(Regex Regex, Func<string, Token> Creator);
}
