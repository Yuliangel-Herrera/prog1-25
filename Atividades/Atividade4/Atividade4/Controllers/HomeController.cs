using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Atividade4.Models;

namespace Atividade4.Controllers;

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


    public int[] dias = new int[7];
    
    public string Getif(int dia)
    {
        if (dia == 1)
        {
            return "Segunda-feira";
        }
        else if (dia == 2)
        {
            return "Terça-feira";
        }
        else if (dia == 3)
        {
            return "Quarta-feira";
        }
        else if (dia == 4)
        {
            return "Quinta-feira";
        }
        else if (dia == 5)
        {
            return "Sexta-feira";
        }
        else if (dia == 6)
        {
            return "Sábado";
        }
        else if (dia == 7)
        {
            return "Domingo";
        }
        else
        {
            return "Dia inválido";
        }
    }

}
