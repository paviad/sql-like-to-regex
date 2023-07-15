namespace SqlLikeToRegex.Test;

public class LikeTests {
    [Theory]
    [InlineData("a%", "^a.*$")]
    [InlineData("a_", "^a.$")]
    [InlineData("a.", "^a\\.$")]
    [InlineData("a[.]", "^a[.]$")]
    [InlineData("%abc[%]%", "^.*abc[%].*$")]
    public void TestLike(string likeExpr, string expected) {
        var rc = SqlLikeTranspiler.ToRegEx(likeExpr);
        Assert.Equal(expected, rc);
    }
}
