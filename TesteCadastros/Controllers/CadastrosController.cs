using Microsoft.AspNetCore.Mvc;
using TesteCadastros.Data;
using TesteCadastros.Models;
using System;
using System.Threading.Tasks;

namespace TesteCadastros.Controllers
{
    public class CadastrosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CadastrosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Cadastros()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastros(Produto model)
        {
            if (!ModelState.IsValid)
            {
                TempData["MensagemErro"] = "Preencha todos os campos corretamente.";
                return View(model);
            }

            try
            {
                model.DataRegistro = DateTime.Now.ToString(); // Define a data de registro automática
                _context.Produtos.Add(model);
                await _context.SaveChangesAsync();

                TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                return RedirectToAction("Cadastros");
            }
            catch (Exception ex)
            {
                TempData["MensagemErro"] = "Erro ao cadastrar o produto. Tente novamente.";
                Console.WriteLine(ex.Message); // Apenas para debug
                return View(model);
            }
        }
    }
}
