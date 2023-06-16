namespace SqlLikeToRegex;

public class ParseException : Exception {
    public int Position { get; set; }

    public ParseException(string message, int position) : base(message) {
        Position = position;
    }
}
