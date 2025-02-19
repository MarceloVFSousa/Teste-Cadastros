using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteCadastros.Data;
using TesteCadastros.Models;
using TesteCadastros.ViewModels;

namespace TesteCadastros.Controllers;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(ApplicationDbContext context, ILogger<HomeController> logger)
    {
        _context = context;
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
        var produtos = _context.Produtos
            .Select(p => new ProdutoViewModel
            {
                Id = p.Id,
                NomeProduto = p.NomeProduto,
                Preco = p.Preco,
                DataRegistro = p.DataRegistro,
                DataPrevisao = p.DataPrevisao,
                Cidade = p.Cidade,
                Estado = p.Estado,
                Cep = p.Cep
            })
            .ToList();

        return View(produtos);
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
