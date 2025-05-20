using Microsoft.AspNetCore.Mvc;

namespace Aula1.Controllers
{
    public class Result
    {
        public string Texto = string.Empty;
    }
    public class TesteController : Controller
    {
        private readonly ILogger<TesteController> _logger;

        public TesteController(ILogger<TesteController> logger)
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
            resultado.Texto = texto.ToUpper();

            return View("Index", resultado);
        }
    }
}
