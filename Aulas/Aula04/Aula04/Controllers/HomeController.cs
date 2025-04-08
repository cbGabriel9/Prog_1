using System.Diagnostics;
using Aula04.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula04.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
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

        [HttpGet]
        public string PrintNaturalFor(int n = 10)
        {
            string retorno = string.Empty;

            int i = 1;

            while (i <= n) // Flag
            {
                retorno += $"{i} "; // Acumulador
                i++; // Contador
            }

            return retorno;
        }

        [HttpGet]
        public string PrintNaturalRecursion(int count = 10)
        {
            string retorno = string.Empty;

            retorno = NaturalNumberRecursion(1, count);
            
            return retorno;
        }

        [HttpGet]
        public string NaturalNumberRecursion(int n, int count)
        {
            string ret = string.Empty;

            // Caso base: Se o contador for menor que 1
            if (count <= 1)
            {
                return $" {n} ";
            }

            // Chamada Recursiva: Incrementa n e decrementa count para imprimir o número
            ret += $" {n} ";
            count--; // Decrementa o count

            ret += NaturalNumberRecursion(n + 1, count);

            return ret;
        }

        [HttpGet]
        public string DecreasingNumber(int n = 10)
        {
            string ret = string.Empty;

            if (n <= 1)
            {
                return $" {n} ";
            }

            ret += $" {n} ";

            ret += DecreasingNumber(n - 1);

            return ret;
        }

        [HttpGet]
        public int SumNumber(int n, int count = 0)
        {
            int soma = 0;

            if (count >= n)
            {
                return soma;
            }

            soma += n;

            soma += SumNumber(n - 1);

            return soma;
        }

        [HttpGet]
        public int ContChar(string palavra, int tamanhoString = 0)
        {

            tamanhoString = palavra.Length;

            if (tamanhoString >= palavra)
            {
                return ca;
            }

            soma += n;

            soma += SumNumber(n - 1);

            return soma;
        }
    }
}
