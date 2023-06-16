using System.Text.RegularExpressions;

namespace SqlLikeToRegex;

internal abstract class Token {
    protected Token(string value) {
        Value = value;
    }

    protected string Value { get; }

    public abstract string Convert();
}

internal class WildcardToken : Token {
    public WildcardToken(string value) : base(value) { }

    public override string Convert() {
        return ".*";
    }
}

internal class WildcharToken : Token {
    public WildcharToken(string value) : base(value) { }

    public override string Convert() {
        return ".";
    }
}

internal class StringToken : Token {
    public StringToken(string value) : base(value) { }

    public override string Convert() {
        return Regex.Escape(Value);
    }
}

internal class SetToken : Token {
    public SetToken(string value) : base(value) { }

    public override string Convert() {
        return Value;
    }
}
