using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Atividade_Recursividade04.Models;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace Atividade_Recursividade04.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
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

    // Programa recursivo para imprimir os número de n até 1 (decrescente);
    [HttpGet]
    public string Decremento(int n = 5)
    {
        string retorno = string.Empty;

        int i = 1;
        while (i <= n) // Meu Fleg
        {
            retorno += $" {n} ";
            n--;
        }
        return retorno;
    }

    // Programa capaz de sumarizar os números de 1 a n Ex: n = 10 [1+2+3+4+5+6+7+8+9+10];
    public string Soma(int n)
    {
        int S = 0;
        string processo = "";
        for (int i = 1; i <= n; i++)
        {
            S += i;
            processo += $"{i} "; // Número atual
            if (i < n) // Adiciona um "+"
            {
                processo += "+ ";
            }
        }
        return $"Processo: {processo}\nA soma de 1 a {n} é: {S}";
    }

    // Escreva um programa recursivo capaz de contar quantos caracteres tem em uma string;
    public string Contador()
    {
        string palavra = "'O castelo animado'";
        int totalCaracteres = ContarCaracteres(palavra);
        return ($"A string {palavra} possui {totalCaracteres} caracteres.");
    }
    public int ContarCaracteres(string palavra, int index = 0)
    {

        if (index >= palavra.Length)
        {
            return 0;
        }
        return 1 + ContarCaracteres(palavra, index + 1);
    }

    // Escreva um programa recursivo que seja capaz de identificar se uma palavra é ou não um Palímodro
    public bool Polidromo(string palavra)
    {
        if (string.IsNullOrEmpty(palavra))
            return true;

        palavra = new string(palavra.Where(char.IsLetter).ToArray()).ToLower();

        if (palavra.Length <= 1)
            return true;

        if (palavra[0] != palavra[^1])
            return false;

        return Polidromo(palavra[1..^1]);
    }

    public string Main(string[] args)
    {
        string[] palavrasParaTestar = { "ovo" };
        StringBuilder resultados = new StringBuilder();

        foreach (var palavra in palavrasParaTestar)
        {
            bool resultado = Polidromo(palavra);
            resultados.AppendLine($"A palavra '{palavra ?? "null"}' é um palíndromo? {resultado}");
        }

        return resultados.ToString();
    }

}
