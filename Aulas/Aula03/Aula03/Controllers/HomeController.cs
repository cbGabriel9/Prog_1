using System.Diagnostics;
using Aula03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {  
            return View();
        }

        [HttpGet]
        public string GetIf(int x)
        {
            /* 
                Estrutura Sintática do IF:
                if(bool)
                {
                    Sentença caso verdadeira a condição
                }

                Caso o IF tenha apenas uma linha a ser executada, não precisa das chaves
            */

            string retorno = string.Empty;
            // int x = 10;

            if (x > 9)
                retorno = "x é maior que 9";

            // x = 8;
            if (x > 9)
                retorno = "x é maior que 9";
            else
                retorno = "x é menor ou igual que 9";

            // x = 11;

            if (x == 10)
            {
                retorno = "Ora ora ";
                retorno += "X é igual a 10";
            }
            else if (x == 9)
            {
                retorno = "Hmmmmmm ";
                retorno += "x é igual a 9";
            }
            else if (x == 8)
            {
                retorno = "Baaahhhh ";
                retorno += "x é igual a 8 tchê";
            }
            else
                retorno = "Sei lá que número é x";

            return retorno;
        }

        [HttpGet]
        public string GetSwitch(int x)
        {
            string retorno = string.Empty;

            switch (x)
            {
                case 0:
                    retorno = "x é Zero";
                    break;

                case 1:
                    retorno = "x é Um";
                    break;

                case 2:
                    retorno = "x é Dois";
                    break;

                case 3:
                    retorno = "x é Três";
                    break;

                default:
                    retorno = "X é algum número não previsto";
                    break;
            }

            return retorno;
        }

        [HttpGet]
        public string GetFor(int x)
        {

            string retorno = string.Empty;

            /*
                O comando de repetição for possui a seguinte sintaxe
                for (inicializador; condição; expressão de repetição)
                for (int i = 1; i > 0; i++)

                Inicializador = Criação do elemento contador
                Condição = Especifica o teste a ser verificado quando o loop (Flag)
                Expressão de repetição = Ação que será feita como contadora. Geralmente um acúmulo ou um decréscimo (acumulador);
             */

            for (int i = 0; i < x; i++)
            {
                retorno += $"{i}; "; 
            }

            return retorno;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
