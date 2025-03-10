namespace Aula1.Models
{
    public class Variaveis
    {
        // Tipos implicitos
        // var teste = 10;

        // Anotação de Tipos
        public int userCount = 10;

        // uma variavel pode ser declarada e não inicializada 
        public int totalCount;

        // CONSTANTES
        // Para declarar constante utilizamos a palavra CONST (deve ser inicializada quando declarada)
        public const int interestRate = 10;

        // O método construtor é invocado na instanciação do objeto por meio da palavra reservada new
        // Por regra, o construtor sempre tem o mesmo nome da classe
        public Variaveis()
        {
            totalCount = 0;

            // Tipo implícito
            var signalStrength = 20;
            var companyName = "ACME";
        }

        // ATIVIDADE
       public byte MinValue = 0;
       public byte MaxValue = 255;
       public short MMinValue = -32768;
       public short MMaxValue = 32767;
       public int MinValu = -2147483648;
       public int MaxValu = 2147483647;
       public uint MinVal = 0;
       public uint MaxVal = 4294967295;
       public long MinV = -9223372036854775808;
       public long MaxV = 9223372036854775807;

    }
}
