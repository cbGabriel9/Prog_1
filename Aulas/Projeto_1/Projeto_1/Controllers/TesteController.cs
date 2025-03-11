using Microsoft.AspNetCore.Mvc;

namespace Projeto_1.Controllers
{
	public class Result
	{
		public string? Texto;
	}
	public class TesteController : Controller
	{
		private readonly ILogger<TesteController> _logger;

		public TesteController(
			ILogger<TesteController> logger
			)
		{
			_logger = logger;
		}

		[HttpGet]
		public IActionResult Index()
		{
			return View("Index", new Result());
		}

		[HttpPost]
		public IActionResult Index(string texto)
		{
			Result resultado = new();
			int n = 0;

			foreach (char c in texto)

			resultado.Texto = texto.ToUpper();

			return View("Index", resultado);
		}
	}
}