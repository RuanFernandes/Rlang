using rc.enums;

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
        private string _input;
        private KeyValuePair<string, TokenType> _lastToken;
        private List<Token> _tokens;
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
            {"true", TokenType.Type_Boolean},
            {"false", TokenType.Type_Boolean},
            {"null", TokenType.Type_Null},

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
            {".", TokenType.Punctuation_Dot},

            {"\"", TokenType.String_DoubleQuote},
            // {"'", TokenType.String_SingleQuote}, Disabled for now

            {" ", TokenType.Other_Whitespace},
            {"\\t", TokenType.Other_Whitespace},
            {"\\r", TokenType.Other_Whitespace},
            {"\\n", TokenType.Other_Newline},
            {"//", TokenType.Other_Comment},
            {"/*", TokenType.Other_Comment},
            {"*/", TokenType.Other_Comment}
        };

        public void setInput(string input)
        {
            _input = input;
            _tokens = new List<Token>();
            _position = 0;

            Console.WriteLine("Lexer input: " + _input + "\n\n");
        }

        public Lexer()
        {
            _input = "";
            _tokens = new List<Token>();
            _position = 0;

            Console.WriteLine("Lexer created\n\n");
        }

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
                    // Read Strings
                    if (token.Type == TokenType.String_DoubleQuote)
                    {
                        string str = "";
                        while (_position < _input.Length && _input[_position] != '"')
                        {
                            str += _input[_position];
                            _position++;
                        }

                        _position++;
                        _tokens.Add(new Token(TokenType.Type_String, str));
                        _lastToken = new KeyValuePair<string, TokenType>(str, TokenType.Type_String);
                    }
                    // Skip comments
                    else if (token.Type == TokenType.Other_Comment)
                    {
                        if (token.Value == "//")
                        {
                            while (_position < _input.Length &&
                                                            !(_input.Substring(_position).StartsWith("\\n") ||
                                                            _input.Substring(_position).StartsWith("\\r")))
                            {
                                _position++;
                            }
                        }
                        _tokens.Add(token);
                    }
                    else
                    {
                        _tokens.Add(token);
                        _lastToken = new KeyValuePair<string, TokenType>(token.Value, token.Type);
                    }

                }
                else
                {
                    // Find var definitions
                    if (_lastToken.Value == TokenType.Variable_Type
                                                                && _lastToken.Value != TokenType.Type_Boolean
                                                                && _lastToken.Value != TokenType.Type_Null
                                                                && _lastToken.Value != TokenType.Type_Number)
                    {
                        string varIdentifier = "";

                        while (_position < _input.Length && char.IsLetterOrDigit(_input[_position]))
                        {
                            varIdentifier += _input[_position];

                            _position++;
                        }

                        _tokens.Add(new Token(TokenType.Variable_Identifier, varIdentifier));
                        _lastToken = new KeyValuePair<string, TokenType>(varIdentifier, TokenType.Variable_Identifier);
                    }
                    // Find Numbers
                    else if (char.IsDigit(_input[_position])
                                                            && _lastToken.Value != TokenType.Type_Boolean
                                                            && _lastToken.Value != TokenType.Type_Null
                                                            && _lastToken.Value != TokenType.Type_Number)
                    {
                        string number = "";
                        while (_position < _input.Length && char.IsDigit(_input[_position]))
                        {
                            number += _input[_position];

                            _position++;
                        }

                        _tokens.Add(new Token(TokenType.Type_Number, number));
                        _lastToken = new KeyValuePair<string, TokenType>(number, TokenType.Type_Number);
                    }
                    // Functions call
                    else if (char.IsLetter(_input[_position]))
                    {
                        string identifier = "";
                        while (_position < _input.Length && char.IsLetterOrDigit(_input[_position]) && _input[_position] != '(')
                        {
                            identifier += _input[_position];

                            _position++;
                        }

                        _tokens.Add(new Token(TokenType.Function_Identifier, identifier));
                        _lastToken = new KeyValuePair<string, TokenType>(identifier, TokenType.Function_Identifier);
                    }
                    // Unknown token
                    else
                    {
                        throw new Exception("Unknown token '" + _input.Substring(_position) + "' at position " + _position + " in input " + _input);
                    }

                }
            }

            // Add EOF token
            _tokens.Add(new Token(TokenType.EOF, "END OF FILE"));

            return _tokens;
        }

        private Token? GetNextToken()
        {
            // Merge All Whitespace into one token
            while (_position < _input.Length && char.IsWhiteSpace(_input[_position]) && _lastToken.Value == TokenType.Other_Whitespace)
            {
                _position++;
            }

            if (_position < _input.Length && char.IsWhiteSpace(_input[_position]) && _lastToken.Value != TokenType.Other_Whitespace)
            {
                _lastToken = new KeyValuePair<string, TokenType>(" ", TokenType.Other_Whitespace);
                return new Token(TokenType.Other_Whitespace, " ");
            }

            // Check if we are at the end of the input
            if (_position >= _input.Length)
                return new Token(TokenType.EOF, "END OF FILE");


            foreach (var tokenType in TokenTypes)
            {
                if (_input.Substring(_position).StartsWith(tokenType.Key))
                {
                    var token = new Token(tokenType.Value, tokenType.Key);

                    // Double slash comment
                    if (tokenType.Value == TokenType.Operator_Divide && _input.Substring(_position + 1).StartsWith("/"))
                    {
                        _position += 2;
                        return new Token(TokenType.Other_Comment, "//");
                    }

                    _position += tokenType.Key.Length;
                    return token;
                }
            }

            return null;
        }
    }
}