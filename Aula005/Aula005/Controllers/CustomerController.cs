using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Model;
using Repository;

namespace Aula005.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IWebHostEnvironment environment;

        private CustomerRepository _customerRepository;

        public CustomerController(IWebHostEnvironment environment) // Metodo construtor tem o mesmo nome da clase e retorna um objeto dele mesmo.
        {
            _customerRepository = new CustomerRepository();
            this.environment = environment;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Customer> customers =
                _customerRepository.RetrieveAll();

            return View(customers);
        }

        [HttpPost]
        public IActionResult Create(Customer c)
        {
            _customerRepository.Save(c);

            List<Customer> customers =
                _customerRepository.RetrieveAll();

            return View("Index", customers);
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
                foreach (Customer c in CustomerData.Customers)
                {
                    fileContent +=
                        String.Format("{0:5}{1:64}", c.Id, c.Name) + // Pode concatenar assim como no Nome tmb
                        String.Format("{0:5}", c.HomeAddres!.Id) +
                        String.Format("{0:32}", c.HomeAddres!.City) +
                        String.Format("{0:2}", c.HomeAddres!.State) +
                        String.Format("{0:32}", c.HomeAddres!.Country) +
                        String.Format("{0:64}", c.HomeAddres!.Street) +
                        String.Format("{0:8}", c.HomeAddres!.cep) +
                        "\n";
                }


            SaveFile(fileContent, "DelimitatedFile.txt");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult ExportFixedFile()
        {
            string fileContent = string.Empty;
            foreach (Customer c in CustomerData.Customers)
            {
                fileContent +=
                    $"{c.Id};{c.Name};{c.HomeAddres!.Id};{c.HomeAddres.City};{c.HomeAddres.State};{c.HomeAddres.Country};{c.HomeAddres.Street};{c.HomeAddres.cep}\n";
            }

            SaveFile(fileContent, "FixedFile.txt");

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id is null || id.Value <= 0)  // is or == diferenças??
                return NotFound();

                Customer customer = _customerRepository.Retrieve(id.Value);

            if (customer == null)
                return NotFound();

            return View(customer);
        }

        [HttpPost]
        public IActionResult ConfirmDelete(int? id)
        {
            if (id is null || id.Value <= 0)
                return NotFound();

            if(!_customerRepository.DeleteById(id.Value))
                return NotFound();

            return RedirectToAction("Index");
        }

        private bool SaveFile(string content, string fileName)
        {
            bool ret = true;

            var path = Path.Combine(
               environment.WebRootPath,
               "TextFiles"
            );

            try
            {

                if (!System.IO.Directory.Exists(path))
                    System.IO.Directory.CreateDirectory(path);

                var filepath = Path.Combine(
                    path,
                    fileName
                    );

                using (StreamWriter sw = System.IO.File.CreateText(filepath))
                {
                    sw.Write(content);
                }

            }

            catch (IOException ioEx)
            {
                string msg = ioEx.Message;
                ret = false;
                // throw ioEx;
            }

                return ret;
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null || id.Value <= 0)
                return NotFound();

            var customer = _customerRepository.Retrieve(id.Value);
            if (customer == null)
                return NotFound();

            return View(customer); // abre a view Update.cshtml
        }

        [HttpPost]
        public IActionResult ConfirmUpdate(Customer updatedCustomer)
        {
            if (updatedCustomer == null || !updatedCustomer.Validade())
                return View("Update", updatedCustomer); // Validação falhou, retorna para a view

            // Atualiza o cliente no repositório
            _customerRepository.Update(updatedCustomer);

            // Recarrega todos os clientes atualizados e exibe a lista
            List<Customer> customers = _customerRepository.RetrieveAll();
            return View("Index", customers);
        }

    }
}
