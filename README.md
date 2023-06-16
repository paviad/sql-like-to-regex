# Sql Like to Regex

This library converts SQL LIKE expressions to regular expressions.

It is based on a C# translation of the Java code from Damon Sutherland at https://codereview.stackexchange.com/a/207486/274158

## Obtaining from Nuget.Org

`dotnet add package SqlLikeToRegex`

## Usage

Call the static method `SqlLikeTranspiler.ToRegEx` to convert an `SQL` `LIKE` expression to a regular expression. The function returns a `string` (not a `Regex` object).

### Example

`var result = SqlLikeTranspiler.ToRegEx("%abc[%]%")`

The expected result is `^.*abc[%].*$`

## Source

The source for this library is on GitHub at https://github.com/paviad/sql-like-to-regex
