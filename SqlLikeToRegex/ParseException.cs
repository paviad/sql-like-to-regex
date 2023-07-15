namespace SqlLikeToRegex;

public class ParseException : Exception {
    public ParseException(string message, int position) : base(message) {
        Position = position;
    }

    public int Position { get; set; }
}
