using Microsoft.AspNetCore.Mvc;
using Modelo;
using Repository;

namespace GerenciamentoImoveis.Controllers
{
    public class PropertyController : Controller
    {
        private PropertyRepository _propertyRepository;
        private readonly IWebHostEnvironment environment;
        private static int highId = 0;
        public PropertyController(IWebHostEnvironment environment)
        {
            _propertyRepository = new PropertyRepository();
            this.environment = environment;

            if (highId == 0)
            {
                highId = PropertyData.Properties.Max(p => p.Id);
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult List()
        {
            List<Property> properties = _propertyRepository.RetrieveAll();

            return View("List", properties);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        public IActionResult ConfirmRegister(Property property)
        {
            highId++;
            property.Id = highId; 
            property.Category = Request.Form["Category"];
            property.Value = float.Parse(Request.Form["Value"]!);
            property.Description = Request.Form["Description"];
            property.CurrentOwner = Request.Form["CurrentOwner"];
            property.BusinessType = Request.Form["BusinessType"];
            property.Address = Request.Form["Address"];
            property.SquareFeet = float.Parse(Request.Form["SquareMeter"]!);
            property.PhotoUrl = Request.Form["PhotoUrl"];

            PropertyData.Properties.Add(property);

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Property? property = PropertyData.Properties.FirstOrDefault(p => p.Id == id);
            if (property != null)
            {
                PropertyData.Properties.Remove(property);
            }
            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id is null || id.Value < 0)
                return NotFound();

            Property property = _propertyRepository.Retrieve(id.Value);

            if (property == null)
                return NotFound();

            return View("Update", property);
        }

        [HttpPost]
        public IActionResult ConfirmUpdate(Property property)
        { 
            Property? oldProperty = PropertyData.Properties.FirstOrDefault(p => p.Id == property.Id);
            
            if (oldProperty == null)
                return NotFound();

            oldProperty.Category = property.Category;
            oldProperty.Value = property.Value;
            oldProperty.Description = property.Description;
            oldProperty.CurrentOwner = property.CurrentOwner;
            oldProperty.BusinessType = property.BusinessType;
            oldProperty.Address = property.Address;
            oldProperty.SquareFeet = property.SquareFeet;
            oldProperty.PhotoUrl = property.PhotoUrl;

            return RedirectToAction("List");
        }
    }
}
