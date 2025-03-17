namespace Aula02.Models
{
    public class DataType
    {
        public char myVar = 'a';

        public const char myConst = 'b';

        public char myChar1 = 'f';
        public char myChar2 = ':';
        public char myChar3 = 'x';

        // Podemos também atribuir referência de caracteres Unicode

        public char myChar4 = '\u2726';

        // Podemos ainda mesclar caracteres especiais como, nova linha, tabulação e etc.

        string textline = "Esta é uma linha de texto.\n\n\nE esta é outra linha";

        /*
          \e - Caractere de escape
          \n - Nova linha
          \r - Retorno
          \t - Tabulação horizontal
          \" - Aspas duplas, usadas para exibir aspas dentro de uma string
          \' - Aspas simples, usadas para exibir aspa simples na string
        */
    }
}
