using rc.enums;
using System;
using System.Collections.Generic;

namespace rc.core
{
    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
    public class Lexer
    {

        private readonly string _input;
        private readonly List<Token> _tokens;
        private int _position;

        private static readonly Dictionary<string, TokenType> TokenTypes = new Dictionary<string, TokenType>
        {
            {"this.", TokenType.Variable_Type},
            {"temp.", TokenType.Variable_Type},

            {"if", TokenType.Keyword_If},
            {"else", TokenType.Keyword_Else},
            {"while", TokenType.Keyword_While},
            {"for", TokenType.Keyword_For},
            {"return", TokenType.Keyword_Return},
            {"break", TokenType.Keyword_Break},
            {"continue", TokenType.Keyword_Continue},
            {"function", TokenType.Keyword_Function},
            {"var", TokenType.Keyword_Var},
            {"true", TokenType.Keyword_True},
            {"false", TokenType.Keyword_False},
            {"null", TokenType.Keyword_Null},
            {"undefined", TokenType.Keyword_Undefined},

            {"+", TokenType.Operator_Plus},
            {"-", TokenType.Operator_Minus},
            {"*", TokenType.Operator_Multiply},
            {"/", TokenType.Operator_Divide},
            {"%", TokenType.Operator_Modulus},
            {"=", TokenType.Operator_Assignment},
            {"==", TokenType.Operator_Equal},
            {"!=", TokenType.Operator_NotEqual},
            {"<", TokenType.Operator_LessThan},
            {">", TokenType.Operator_GreaterThan},
            {"<=", TokenType.Operator_LessThanOrEqual},
            {">=", TokenType.Operator_GreaterThanOrEqual},
            {"&&", TokenType.Operator_And},
            {"||", TokenType.Operator_Or},
            {"!", TokenType.Operator_Not},

            {"(", TokenType.Punctuation_OpenParenthesis},
            {")", TokenType.Punctuation_CloseParenthesis},
            {"{", TokenType.Punctuation_OpenCurlyBrace},
            {"}", TokenType.Punctuation_CloseCurlyBrace},
            {"[", TokenType.Punctuation_OpenSquareBracket},
            {"]", TokenType.Punctuation_CloseSquareBracket},
            {",", TokenType.Punctuation_Comma},
            {";", TokenType.Punctuation_Semicolon},

            {"\"", TokenType.String_DoubleQuote},
            {"'", TokenType.String_SingleQuote},

            {" ", TokenType.Other_Whitespace},
            {"\t", TokenType.Other_Whitespace},
            {"\r", TokenType.Other_Whitespace},
            {"\n", TokenType.Other_Newline},
            {"//", TokenType.Other_Comment},
            {"/*", TokenType.Other_Comment},
            {"*/", TokenType.Other_Comment}
        };

        public Lexer(string input)
        {
            _input = input;
            _tokens = new List<Token>();
            _position = 0;
        }

        public List<Token> Tokenize()
        {
            while (_position < _input.Length)
            {
                var token = GetNextToken();
                if (token != null)
                {
                    _tokens.Add(token);
                }
                else
                {
                    throw new Exception("Unknown token");
                }
            }

            return _tokens;
        }

        private Token? GetNextToken()
        {
            while (_position < _input.Length && char.IsWhiteSpace(_input[_position]))
                _position++;

            if (_position >= _input.Length)
                return null;

            foreach (var tokenType in TokenTypes)
            {
                if (_input.Substring(_position).StartsWith(tokenType.Key))
                {
                    var token = new Token(tokenType.Value, tokenType.Key);
                    _position += tokenType.Key.Length;
                    return token;
                }
            }

            return null;
        }
    }
}