using Microsoft.AspNetCore.Mvc;
using Atividade3.Models;

namespace Atividade3.Controllers
{
    public class Result
    {
        public string? numeroOriginal { get; set; }
        public string? ultimaPilha { get; set; }
        public string? numeroExtenso { get; set; }
    }

    public class ChequeController : Controller
    {
        private readonly ILogger<ChequeController> _logger;

        public ChequeController(ILogger<ChequeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("Index", new Result());
        }

        [HttpPost]
        public IActionResult Converter(string numero_original)
        {
            // Criei a instância do result pra passar pra view
            Result resultado = new();

            resultado.numeroOriginal = numero_original;

            // Criei o array bidimensional para armazenar os valores padrões dos números
            string[,] numeros = new string[,]
            {
                {"", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove"},
                {"", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa"},
                {"", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seissentos", "setecentos", "oitocentos", "novecentos"}
            };

            int volta = 1;

            // Criei a pilha pra ordenar os char do número digitado ao contrário, para que o meu foreach leia do início dos números para o final
            Stack<char> pilhaParaOrdenarChar = new();

            // Criei a pilha pra ordenar os char depois que forem transformados em string, o número por extenso no caso
            Stack<string> pilhaParaOrdenarString = new();

            // Essa variável serve para ser a string que vai receber a frase por completa
            string? num_invertido = "";

            string? num_extenso = string.Empty;

            // Servirá para indicar se o número estará na casa da unidade, dezena ou centena
            int linha = 0;

            // Servirá para indicar a escrita do número
            int coluna = 0;

            // Aqui estou iterando sobre cada char do meu número original, para verificar qual é ele no meu array bidimensional
            foreach (char num in numero_original)
            {
                pilhaParaOrdenarChar.Push(num);
            }
            ;

            // Fazer com que num_invertido receba os itens da pilha, agora com a sequência ivnertida
            while (pilhaParaOrdenarChar.Count > 0)
            {
                num_invertido += pilhaParaOrdenarChar.Pop();
            }
            ;

            foreach (char num in num_invertido)
            {
                coluna = (int)char.GetNumericValue(num);

                if (linha >= 0 && linha < 3 && coluna >= 0 && coluna < 10)
                {
                    if (num != '0' && volta != 4 && volta != 7 && volta != 10)
                    {
                        pilhaParaOrdenarString.Push(" e ");
                        pilhaParaOrdenarString.Push(numeros[linha, coluna]);
                    }
                    else if (volta == 4)
                    {
                        if (num != '0')
                        {
                            pilhaParaOrdenarString.Push(" mil e ");
                            pilhaParaOrdenarString.Push(numeros[linha, coluna]);
                        }
                        else
                        {
                            pilhaParaOrdenarString.Push(" mil e ");
                        }
                        
                    }
                    else if ( volta == 7)
                    {
                        if (num!= '0')
                        {
                            pilhaParaOrdenarString.Push(" milhões, ");
                            pilhaParaOrdenarString.Push(numeros[linha, coluna]);
                        } 
                        else
                        {
                            pilhaParaOrdenarString.Push(" milhões, ");
                        }
                    }
                    else if (volta == 10)
                    {
                        if(num != '0')
                        {
                            pilhaParaOrdenarString.Push(" bilhões, ");
                            pilhaParaOrdenarString.Push(numeros[linha, coluna]);
                        }
                        else
                        {
                            pilhaParaOrdenarString.Push(" bilhões, ");
                        }
                        
                    }
                    else if (num == 0)
                    {

                    }
                }

                coluna += 1;
                linha += 1;
                volta += 1;

                if (coluna > 9)
                {
                    coluna = 0;
                }

                if (linha > 2)
                {
                    linha = 0;
                }
            }

            while (pilhaParaOrdenarString.Count > 1)
            {
                num_extenso += pilhaParaOrdenarString.Pop();
            };

            resultado.ultimaPilha = pilhaParaOrdenarString.Peek();

            if (pilhaParaOrdenarString.Peek() != " e ")
            {
                if (pilhaParaOrdenarString.Peek() == " mil e ")
                   num_extenso += " mil";

                if (pilhaParaOrdenarString.Peek() == " milhões e ")
                    num_extenso += " milhões";

                if (pilhaParaOrdenarString.Peek() == " bilhões e ")
                    num_extenso += " bilhões";
            }

            num_extenso += " reais";

            num_extenso = num_extenso.Replace("dez e um", "onze");
            num_extenso = num_extenso.Replace("dez e dois", "doze");
            num_extenso = num_extenso.Replace("dez e três", "treze");
            num_extenso = num_extenso.Replace("dez e quatro", "quatorze");
            num_extenso = num_extenso.Replace("dez e cinco", "quinze");
            num_extenso = num_extenso.Replace("dez e seis", "dezesseis");
            num_extenso = num_extenso.Replace("dez e sete", "dezessete");
            num_extenso = num_extenso.Replace("dez e oito", "dezoito");
            num_extenso = num_extenso.Replace("dez e nove", "dezenove");

            resultado.numeroExtenso = num_extenso;

            return View("Index", resultado);
        }
    }
}
