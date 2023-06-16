using System.Text.RegularExpressions;

namespace SqlLikeToRegex;

public abstract class Token {
    protected string Value { get; }

    protected Token(string value) {
        Value = value;
    }

    public abstract string Convert();
}

public class WildcardToken : Token {
    public WildcardToken(string value) : base(value) { }

    public override string Convert() {
        return ".*";
    }
}

public class WildcharToken : Token {
    public WildcharToken(string value) : base(value) { }

    public override string Convert() {
        return ".";
    }
}

public class StringToken : Token {
    public StringToken(string value) : base(value) { }

    public override string Convert() {
        return Regex.Escape(Value);
    }
}

public class SetToken : Token {
    public SetToken(string value) : base(value) { }

    public override string Convert() {
        return Value;
    }
}
