using Microsoft.AspNetCore.Mvc;
using Atividade3.Models;

namespace Atividade3.Controllers
{

    public class ChequeController : Controller
    {
        public class Result {
            public int numeroOriginal { get; set; }
        }

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

        public IActionResult Converter(int numero_original)
        {
            Result resultado = new();

            resultado.numeroOriginal = numero_original;
            return View("Index", resultado.numeroOriginal);
        }
    }
}
