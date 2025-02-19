using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TesteCadastros.Models;

namespace TesteCadastros.Controllers;

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

    public IActionResult Dashboard() 
    {
        return View();
    }

    public IActionResult Cadastros() 
    {
        return View();
    }

    public IActionResult CadastroSucesso()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

}
