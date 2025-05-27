using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace Aula05.Controllers
{
    public class ProductController : Controller
    {
        private ProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _productRepository.RetrieveAll();

            return View(products);
        }

        [HttpPost]
        public IActionResult Create(Product c)
        {
            _productRepository.Save(c);
            List<Product> products = _productRepository.RetrieveAll();

            return View("Index", products);
        }

        [HttpPost]
        public IActionResult Update()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
    }
}
