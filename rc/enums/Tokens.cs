namespace rc.enums
{
    public enum Tokens
    {
        EOF,                // fim do arquivo
        Identificador,      // identificador (nome de variável, função, etc)
        Inteiro,            // número inteiro
        Float,              // número decimal
        OperadorAritmetico, // operador aritmético (+, -, *, /)
        OperadorRelacional, // operador relacional (>, <, >=, <=, ==, !=)
        OperadorLogico,     // operador lógico (&&, ||, !)
        Delimitador,        // delimitador (, ;, {, })
        PalavraChave,       // palavra-chave (if, while, for, etc)
        String,             // string ("texto")
        Comentario,         // comentário (//, /* */)
        Funcao,             // função (print, read, etc)
    }
}