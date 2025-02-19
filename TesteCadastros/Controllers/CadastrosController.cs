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

        public IActionResult CadastroSucesso()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Cadastros()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastros(Produto model)
        {
            Console.WriteLine("Método POST Cadastros foi chamado!");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ ModelState inválido!");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Erro: {error.ErrorMessage}");
                }
                TempData["MensagemErro"] = "Preencha todos os campos corretamente.";
                return View(model);
            }

            try
            {
                model.DataRegistro = DateTime.Now;
                Console.WriteLine($"Dados Recebidos -> Nome: {model.NomeProduto}, Preço: {model.Preco}");

                Console.WriteLine("Antes de salvar no banco");
                _context.Produtos.Add(model);
                Console.WriteLine("Salvando no banco...");
                var rowsAffected = await _context.SaveChangesAsync();

                if (rowsAffected > 0)
                {
                    Console.WriteLine("Produto salvo com sucesso no banco!");
                }
                else
                {
                    Console.WriteLine("Nenhum registro foi salvo!");
                }

                TempData["MensagemSucesso"] = "Produto cadastrado com sucesso!";
                //return RedirectToAction("Cadastros");
                return RedirectToAction("CadastroSucesso", "Home");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message} | StackTrace: {ex.StackTrace}");
                TempData["MensagemErro"] = "Erro ao cadastrar o produto. Verifique o console.";
                return View(model);
            }
        }

    }
}
