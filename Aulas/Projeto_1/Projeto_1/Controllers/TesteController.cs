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
			char[] alfabeto = new char[26] {'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'};
			List<char> palavraCodificada;
			int n = 0;

			resultado.Texto = texto.ToLower();
			foreach (char c in texto)
			{
				if (Array.IndexOf(alfabeto, c) != -1)
				{
                    palavraCodificada.Add(c);
				}
			}

			return View("Index", resultado);
		}
	}
}