using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace GerenciamentoImoveis.Controllers
{
    public class PropertyController : Controller
    {
        private PropertyRepository _propertyRepository;
        private readonly IWebHostEnvironment environment;
        public PropertyController(IWebHostEnvironment environment)
        {
            _propertyRepository = new PropertyRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RetrieveAll()
        {
            List<Property> properties = _propertyRepository.RetrieveAll();

            return View("List", properties);
        }
    }
}
