namespace rc.enums
{
    public enum TokenType
    {
        // Variables
        Variable_Type,
        Variable_Identifier,
        Variable_Value,

        // Keywords
        Keyword_If,
        Keyword_Else,
        Keyword_While,
        Keyword_For,
        Keyword_Return,
        Keyword_Break,
        Keyword_Continue,
        Keyword_Function,

        // Operators
        Operator_Plus,
        Operator_Minus,
        Operator_Multiply,
        Operator_Divide,
        Operator_Modulus,
        Operator_Assignment,
        Operator_Equal,
        Operator_NotEqual,
        Operator_LessThan,
        Operator_GreaterThan,
        Operator_LessThanOrEqual,
        Operator_GreaterThanOrEqual,
        Operator_And,
        Operator_Or,
        Operator_Not,

        // Punctuation
        Punctuation_OpenParenthesis,
        Punctuation_CloseParenthesis,
        Punctuation_OpenCurlyBrace,
        Punctuation_CloseCurlyBrace,
        Punctuation_OpenSquareBracket,
        Punctuation_CloseSquareBracket,
        Punctuation_Comma,
        Punctuation_Semicolon,
        Punctuation_Dot,

        // String
        String_DoubleQuote,
        String_SingleQuote,

        // Other
        Other_Whitespace,
        Other_Newline,
        Other_Comment,
        Other_Unknown,

        // Types
        Type_Number,
        Type_String,
        Type_Boolean,
        Type_Null,

        // End of file
        EOF
    }
}