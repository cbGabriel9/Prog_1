using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.ObjectPool;

namespace Projeto_1.Controllers
{
	public class Result
	{
		// Aqui eu preciso criar as variáveis que serão passadas para a página html como o resultado, por isso o nome "result"
		public string? Texto { get; set; }
		public int? Passo { get; set; }
		public List<char>? palavraCodificada { get; set; }
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
		public IActionResult Index(string texto, int n, string tipo)
		{
			// Preciso criar uma instância do Result para utilizar e retornar algo do meu procedimento
			Result resultado = new();
			// Criei o array para fazer a verificacao dos caracteres das palavras digitadas e retornar o caractere depois de n posicoes
			char[] alfabeto = new char[26] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
			// Criei a lista para conforme for fazendo a verificacao de char no array ele ir armazenando o char para apresenta o resultado final com as letras juntas no html
			List<char> palavraCodificada = new();
			// Transforma o texto digitado em letras minúsculas
			resultado.Texto = texto.ToLower();

			if (tipo == "Codificar")
			{

				// Aqui eu faco a verificacao de cada char da palavra digitada e retorna cada valor dps de n casas na lista palavraCodificada
				foreach (char c in resultado.Texto)
				{
					// Faz uma verificacao para manter os espacos pois eles nao sao codificados
					if (c == ' ' || char.IsDigit(c))
					{
						palavraCodificada.Add(c);
					}

					if (Array.IndexOf(alfabeto, c) != -1)
					{
						// Aqui atribuo a var i a posicao do array para ser passada como parâmetro depois no array alfabeto,
						// Utilizei o módulo para caso o número ultrapasse 26, o módulo me retorne o resto para continuar a codificacao do início com o excedente
						// Caso o valor seja menor que 26 a funcao de modulo retorna o numero da posicao normal
						int i = (Array.IndexOf(alfabeto, c) + n) % alfabeto.Length;
						palavraCodificada.Add(alfabeto[i]);
					}

				}
			}
			else
			{
				foreach (char c in resultado.Texto)
				{
					if (c == ' ' || char.IsDigit(c))
					{
						palavraCodificada.Add(c);
					}

					if (Array.IndexOf(alfabeto, c) != -1)
					{
						int i = ((Array.IndexOf(alfabeto, c) - n) + 26 ) % alfabeto.Length;
						palavraCodificada.Add(alfabeto[i]);
					}
				}
			}
				resultado.Passo = n;
			// Aqui eu atribuo a List para a variável Result resultado, pois é o formato que precisa ser passado ao html, entao eu jogo a lista ali dentro e passo o result pro html
			resultado.palavraCodificada = palavraCodificada;

			// Abre a view html passando o parâmetro resultado
			return View("Index", resultado);
		}
	}
}