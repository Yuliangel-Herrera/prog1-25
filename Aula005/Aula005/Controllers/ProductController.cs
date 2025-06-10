using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;

namespace Aula005.Controllers
{
    public class ProductController : Controller
    {

        private readonly IWebHostEnvironment environment;

        private ProductRepository _productRepository;

        public ProductController(IWebHostEnvironment environment)
        {
            _productRepository = new ProductRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = _productRepository.RetrieveAll();
            return View(products);
        }

        [HttpPost]
        public IActionResult Create(Product p)
        {
            _productRepository.Save(p);

            List<Product> products =
               _productRepository.RetrieveAll();

            return View("Index", products);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ExportDelimitatedFile()
        {
            string fileContent = string.Empty;
            foreach (Product p in ProductData.Products)
            {
                fileContent +=
                    $"{p.Id};{p.Name};{p.Description};{p.CurrentPrice}\n";
            }

            var path = Path.Combine(
                environment.WebRootPath, "TextFiles");

            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            var filepath = Path.Combine(
                environment.WebRootPath, "TextFiles", "Delimitado.txt");

            if (!System.IO.File.Exists(filepath))
            {
                using (StreamWriter sw = System.IO.File.CreateText(filepath))
                {
                    sw.WriteLine(fileContent);
                }
            }

            return View();
        }
    }
}
