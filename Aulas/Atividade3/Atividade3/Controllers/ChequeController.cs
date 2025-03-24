using Microsoft.AspNetCore.Mvc;
using Atividade3.Models;

namespace Atividade3.Controllers
{
    public class Result
    {
        public string? numeroOriginal { get; set; }
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
            Result resultado = new();

            resultado.numeroOriginal = numero_original;

            string[,] numeros = new string[,]
            {
                {"", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove"},
                {"", "dez", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa"},
                {"", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seissentos", "setecentos", "oitocentos", "novecentos"}
            };

            int volta = 1;

            Stack<char> pilhaParaOrdenarChar = new();

            Stack<string> pilhaParaOrdenarString = new();

            string? num_invertido = "";

            int linha = 0;

            int coluna = 0;

            foreach (char num in numero_original)
            {
                pilhaParaOrdenarChar.Push(num);
            };

            while (pilhaParaOrdenarChar.Count > 0)
            {
                num_invertido += pilhaParaOrdenarChar.Pop();
            };

            foreach (char num in num_invertido)
            {
                coluna = (int)char.GetNumericValue(num);

                    if (linha >= 0 && linha < 3 && coluna >= 0 && coluna < 10)
                    {
                        if(num != '0' && volta < 4)
                        {
                            pilhaParaOrdenarString.Push(" e ");
                            pilhaParaOrdenarString.Push(numeros[linha, coluna]);

                        } else if (num != '0' && volta == 4)
                        {
                            pilhaParaOrdenarString.Push(" mil, ");
                            pilhaParaOrdenarString.Push(numeros[linha, coluna]);
                        }
                        else if (num != '0' && volta == 8)
                        {
                            pilhaParaOrdenarString.Push(" milhões, ");
                            pilhaParaOrdenarString.Push(numeros[linha, coluna]);
                        }
                        else if (num != '0' && volta == 12)
                        {
                            pilhaParaOrdenarString.Push(" bilhões, ");
                            pilhaParaOrdenarString.Push(numeros[linha, coluna]);
                        }
                        else if (num != 0)
                        {
                            pilhaParaOrdenarString.Push(numeros[linha, coluna]);
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
                resultado.numeroExtenso += pilhaParaOrdenarString.Pop();
            };

            resultado.numeroExtenso += " reais";

            return View("Index", resultado);
        }
    }
}
