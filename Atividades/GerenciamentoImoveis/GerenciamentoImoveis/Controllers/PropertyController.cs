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
            return View(); // Esta ação é utilizada para ir a página inicial dos imóveis 
        }

        [HttpGet]
        public IActionResult List(string? category, string? businesstype) // Ele passa 2 parâmetros opcionais para que dê certo o filtro da categoria e do tipo de negócio
        {
            List<Property> properties = _propertyRepository.RetrieveAll(); // Cria uma variável que recebe todos os imóveis criados

            if(!string.IsNullOrEmpty(category))
            {
                properties = properties.Where(p => p.Category == category).ToList(); //Verifica se a categoria passada está settada e caso esteja retorna apenas os imóveis que possuem a categoria passada como parâmetro
            }

            if (!string.IsNullOrEmpty(businesstype))
            {
                properties = properties.Where(p => p.BusinessType == businesstype).ToList();
            }

            return View("List", properties); // Retorna a view List com a lista de imóveis filtrada ou não, dependendo dos parâmetros passados
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register"); // Move para a view Register
        }

        [HttpPost]
        public IActionResult ConfirmRegister(Property property) // É nesta ação que é efetuado o cadastro do imóvel
        {
            highId++; // Incrementa o ID do móvel cada vez que um novo é criado para que o novo imóvel não tenha o mesmo ID
            property.Id = highId; 
            property.Category = Request.Form["Category"]; // Property vai receber os valores do HTML
            property.Value = float.Parse(Request.Form["Value"]!);
            property.Description = Request.Form["Description"];
            property.CurrentOwner = Request.Form["CurrentOwner"];
            property.BusinessType = Request.Form["BusinessType"];
            property.Address = Request.Form["Address"];
            property.SquareMeter = float.Parse(Request.Form["SquareMeter"]!);
            property.PhotoUrl = Request.Form["PhotoUrl"];

            PropertyData.Properties.Add(property); // Adiciona o novo objeto Property a lista de imóveis

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Property? property = PropertyData.Properties.FirstOrDefault(p => p.Id == id); // Busca o imóvel que possui o id passado como parâmetro
            if (property != null)
            {
                PropertyData.Properties.Remove(property);
            }
            return RedirectToAction("List"); // Volta para a lista de imóveis
        }

        [HttpGet]
        public IActionResult Update(int? id) // Serve para carregar a view de atualização de imóvel
        {
            if (id is null || id.Value < 0)
                return NotFound();

            Property property = _propertyRepository.Retrieve(id.Value); // Busca o imóvel que possui o id passado como parâmetro

            if (property == null)
                return NotFound();

            return View("Update", property);
        }

        [HttpPost]
        public IActionResult ConfirmUpdate(Property property) // Quando preenchido o form do html, ele chama essa ação para atualizar o imóvel
        { 
            Property? oldProperty = PropertyData.Properties.FirstOrDefault(p => p.Id == property.Id); // Criei uma variável para armazenar os valores antigos do imóvel
            
            if (oldProperty == null)
                return NotFound();

            oldProperty.Category = property.Category; // Aqui eu faço com que a variável olProperty receba os valores do imóvel passado como parâmetro, assim ele sabe em qual imóvel está alterando
            oldProperty.Value = property.Value;
            oldProperty.Description = property.Description;
            oldProperty.CurrentOwner = property.CurrentOwner;
            oldProperty.BusinessType = property.BusinessType;
            oldProperty.Address = property.Address;
            oldProperty.SquareMeter = property.SquareMeter;
            oldProperty.PhotoUrl = property.PhotoUrl;

            return RedirectToAction("List");
        }

        [HttpGet]
        public IActionResult ExportDelimitedFile()
        {
            string fileContent = string.Empty;

            foreach (Property p in PropertyData.Properties)
            {
                fileContent += $"{p.Id}; {p.Category}; {p.BusinessType}; {p.CurrentOwner}; {p.Value}; {p.SquareMeter}; {p.Address}; {p.Description}; {p.PhotoUrl} \n";
            }

            SaveFile(fileContent, "DelimitedFile.txt");

            return View("ExportDelimitedFile");
        }

        private bool SaveFile(string content, string fileName)
        {
            bool ret = true;

            if (string.IsNullOrEmpty(content) || string.IsNullOrEmpty(fileName))
                return false;

            var path = Path.Combine(
                environment.WebRootPath,
                "TextFiles"
                );

            try
            {

                if (!System.IO.Directory.Exists(path))
                {
                    System.IO.Directory.CreateDirectory(path);
                }

                var filepath = Path.Combine(
                    path,
                    fileName
                    );

                if (!System.IO.File.Exists(filepath)) // Vai verificar se o arquivo que estamos criando já não existe
                {
                    using (StreamWriter sw = System.IO.File.CreateText(filepath))
                    {
                        sw.Write(content);
                    }
                }
            }

            catch (IOException ioEx)
            {
                string msg = ioEx.Message;
                ret = false;
            }
            catch (Exception ex)
            {
                string msg = ex.Message;
                ret = false;
            }
            return ret;
        }

    }
}
