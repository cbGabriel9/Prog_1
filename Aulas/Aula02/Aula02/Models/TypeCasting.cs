namespace Aula02.Models
{
    public class TypeCasting
    {
        // Declarando variáveis na classe

        public int myInteger = 20;
        public long myLong;

        public string myType1;
        public string myType2;

        public TypeCasting()
        {
            // Conversão implícita de tipos
            myLong = myInteger;
            // myInteger = myLong;
            // Neste caso o long é muito grande para o int, então não é permitida a conversão

            // Conversão explícita
            long myLong2 = 138129210;
            int myInteger2;

            myInteger2 = (int)myLong2;

            // É possível identificar qual é o tipo de uma variável em tempo de execução
            myType1 = myLong2.GetType().ToString();
            myType2 = myInteger2.GetType().ToString();
        }
    }
}
