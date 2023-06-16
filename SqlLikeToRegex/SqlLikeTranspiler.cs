using System.Text;

namespace SqlLikeToRegex;

public static class SqlLikeTranspiler {
    private static readonly Tokenizer Tokenizer = new Tokenizer()
        .Add("^(\\[[^]]*])", a => new SetToken(a))
        .Add("^(%)", a => new WildcardToken(a))
        .Add("^(_)", a => new WildcharToken(a))
        .Add("^([^\\[\\]%_]+)", a => new StringToken(a));

    public static string ToRegEx(string pattern) {
        var sb = new StringBuilder().Append('^');
        foreach (var token in Tokenizer.Tokenize(pattern)) {
            sb.Append(token.Convert());
        }

        return sb.Append('$').ToString();
    }
}
