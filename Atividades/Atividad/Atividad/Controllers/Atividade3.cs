using Microsoft.AspNetCore.Mvc;
using NumeroPorExtenso.Models;

namespace NumeroPorExtenso.Controllers
    {
        public class NumeroController : Controller
        {
            [HttpGet]
            public IActionResult Index()
            {
                return View();
            }

            [HttpPost]
            public IActionResult Index(NumeroPorExtensoModel model)
            {
                if (ModelState.IsValid)
                {
                    string resultado = Converter(model.Numero);
                    ViewBag.Resultado = resultado;
                }
                return View(model);
            }

            private string Converter(int numero)
            {
                if (numero < 0 || numero > 9999)
                    throw new ArgumentOutOfRangeException("Número fora do intervalo permitido.");

                string[] unidades = { "zero", "um", "dois", "três", "quatro", "cinco", "seis", "sete", "oito", "nove" };
                string[] dezenas = { "", "", "vinte", "trinta", "quarenta", "cinquenta", "sessenta", "setenta", "oitenta", "noventa" };
                string[] dezenasEspeciais = { "dez", "onze", "doze", "treze", "quatorze", "quinze", "dezesseis", "dezessete", "dezoito", "dezenove" };
                string[] centenas = { "", "cento", "duzentos", "trezentos", "quatrocentos", "quinhentos", "seiscentos", "setecentos", "oitocentos", "novecentos" };

                if (numero == 0) return unidades[0];

                string resultado = "";

                if (numero >= 1000)
                {
                    resultado += unidades[numero / 1000] + " mil ";
                    numero %= 1000;
                }

                if (numero >= 100)
                {
                    resultado += centenas[numero / 100] + " ";
                    numero %= 100;
                }

                if (numero >= 20)
                {
                    resultado += dezenas[numero / 10] + " ";
                    numero %= 10;
                }
                else if (numero >= 10)
                {
                    resultado += dezenasEspeciais[numero - 10] + " ";
                    return resultado.Trim();
                }

                if (numero > 0)
                {
                    resultado += unidades[numero] + " ";
                }

                return resultado.Trim();
            }
        }
    }