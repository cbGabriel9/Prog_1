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
                Estrutura Sint�tica do IF:
                if(bool)
                {
                    Senten�a caso verdadeira a condi��o
                }

                Caso o IF tenha apenas uma linha a ser executada, n�o precisa das chaves
            */

            string retorno = string.Empty;
            // int x = 10;

            if (x > 9)
                retorno = "x � maior que 9";

            // x = 8;
            if (x > 9)
                retorno = "x � maior que 9";
            else
                retorno = "x � menor ou igual que 9";

            // x = 11;

            if (x == 10)
            {
                retorno = "Ora ora ";
                retorno += "X � igual a 10";
            }
            else if (x == 9)
            {
                retorno = "Hmmmmmm ";
                retorno += "x � igual a 9";
            }
            else if (x == 8)
            {
                retorno = "Baaahhhh ";
                retorno += "x � igual a 8 tch�";
            }
            else
                retorno = "Sei l� que n�mero � x";

            return retorno;
        }

        [HttpGet]
        public string GetSwitch(int x)
        {
            string retorno = string.Empty;

            switch (x)
            {
                case 0:
                    retorno = "x � Zero";
                    break;

                case 1:
                    retorno = "x � Um";
                    break;

                case 2:
                    retorno = "x � Dois";
                    break;

                case 3:
                    retorno = "x � Tr�s";
                    break;

                default:
                    retorno = "X � algum n�mero n�o previsto";
                    break;
            }

            return retorno;
        }

        [HttpGet]
        public string GetFor(int x)
        {

            string retorno = string.Empty;

            /*
                O comando de repeti��o for possui a seguinte sintaxe
                for (inicializador; condi��o; express�o de repeti��o)
                for (int i = 1; i > 0; i++)

                Inicializador = Cria��o do elemento contador
                Condi��o = Especifica o teste a ser verificado quando o loop (Flag)
                Express�o de repeti��o = A��o que ser� feita como contadora. Geralmente um ac�mulo ou um decr�scimo (acumulador);
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
