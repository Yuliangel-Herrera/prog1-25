using System.Diagnostics;
using Aula4.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return View();
        }

        [HttpGet]
        public string GetIf(int x)
        {
            // estrutura sintatica do if
            // if(expresssao booleana){ senten�a de codigo, a ser executada caso a condi��o seja verdadeira }
            // caso o if tenha apenas uma linha de comando a ser executada na condicional n�o h� necessidade do uso das chaves
            // if(expr. bool.) apenas um comando

            string retorno = string.Empty; // igual s� colocar ""
            //int x = 10;

            if (x < 9)
                return "x � maior que nove";

            //x = 8;
            if (x > 9)
                retorno = "x � maior que nove";
            else
                retorno = "x � menor que nove";

            //x = 10;
            if (x > 10)
            {
                retorno = "ora ora";
                retorno += "x � igual a 10";
            }
            else if (x == 9)
            {
                retorno = "hmm";
                retorno += "x � ihual a 9";
            }
            else if (x == 8)
            {
                retorno = "bahh";
                retorno += "x � igual a 8";
            }
            else
            {
                retorno = "que bosta � essa!";
            }

            return retorno;
        }

        [HttpGet]
        public string GetSwitch(int x)
        {
            string retorno = string.Empty;
            switch (x)
            {
                case 0:
                    retorno = "x � zero";
                    break;
                case 1:
                    retorno = "x � um";
                    break;
                case 2:
                    retorno = "x � dois";
                    break;
                case 3:
                    retorno = "x � tres";
                    break;
                default:
                    retorno = "x � algum numero nao previsto";
                    break;
            }

            return retorno;
        }

        [HttpGet]
        public string GetFor(int x)
        {
            /*
            o comando de repeti��o for possue a seguinte sitaxe:
                for (<inicializador>; <exprs. condicional>; <expres. de repeti��o>)
                {comandos a serem executados}
            inicializador: elemento contador, tradicionalmente utilzado o 'i' de indice
            expres. condicional: expecifica o teste a ser veriificado quando o loop estiver executado o numero definido de itera��es (flag)
            expres. de repeti��o: expecifica a a��o a ser executada com a variavel contadora, geralmente um acumulo de ou decressimo
            */
            x = 45;
            string retorno = string.Empty;

            for (int i = 1; i <= x; i++)
            {   // Se eu quissese interrumpir o la�o caso seja maior que 5
                if(i > 50) break; // brwak interrompe o la�o
                retorno = $"{i};";

                // Caso eu deseje o la�o siga enfrente forzando a sua execu��o
                if (i % 2 == 0) continue; // continue for�a a execu��o do la�o  
            }

            return retorno;
        }

        public string Getforeach(string color)
        {
            /* O comando foreach (para cada) � utilizada para iterar por uma sequencia de itens em uma cole��o 
               e servir como uma opc�o simples
               de repeti��o */
            string[] colors = { "Rosa", "Azul-Marinho", "lila", "Celeste", "Amarillo", "blanco", "Preto", "Cinza", "Verde", "Roxo" };
            string retorno = string.Empty;

            if (Colors.Contains(char.ToUpper(color[0] + color.Substring(1))))
               retorno = "Cor encontrada";
            else 
               retorno = "Cor n�o encontrada";
            foreach (string s in colors)
            {
                retorno += $" [{s}]";
            }
         }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}