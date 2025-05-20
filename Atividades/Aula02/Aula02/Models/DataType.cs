namespace Aula02.Models
{
    public class DataType
    {
        public char myVar = 'a';
        public char myConst = 'b';

        public char myChar1 = 'f';
        public char myChar2 = ':';
        public char myChar3 = 'x';

        // Podemos tambem atribuir referencia de caracteres Unicode
        public char myChar4 = '\u2726';

        // Podemos ainda mesclar caracteres especiais como, nova linha, tabulação e etc
        public string textLine =
            "Esta é uma linha de texto. \n\n\nE esta é outra linha.";

        /*
          \e Caracter de escape
        \n nova linha
        \r Retorno
        \t Tabulação horizontal
        \" Exibir aspas duplas dentro de string
        \' Exibir aspas simples na string
        */

        private int count = 10;
        public string message;

        public DataType()
        {
            //Interpolação de string
            //Combinando strings de diferentes maneiras no C#
            message = $"O contador está em {count}";

            string username = "lola";
            int inboxCount = 10;
            int maxCount = 100;

            message += $"\nO usuario {username} tem {inboxCount} mensagens.";
            message += $"\nEspaço restante em sua caixa {maxCount - inboxCount}.";
        }
    }
}
