using System.Diagnostics;
using DiaDaSemana.Models;
using Microsoft.AspNetCore.Mvc;

namespace DiaDaSemana.Controllers
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

        [HttpGet]
        public string DiaDaSemana(int x)
        {
            string[] dias = new string[7] {"Domingo", "Segunda-Feira", "Terça-Feira", "Quarta-Feira", "Quinta-Feira", "Sexta-Feira", "Sábado"};

            string dia_semana = string.Empty;

            x += -1;

            if (x > 6 || x < 0)
            {
                dia_semana = "Número Inválido";
            }
            else if (x >= 0 && x <= 7)
            {
                dia_semana = dias[x];
            }

            return dia_semana;
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
