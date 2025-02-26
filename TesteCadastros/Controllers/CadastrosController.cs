using Microsoft.AspNetCore.Mvc;
using TesteCadastros.Data;
using TesteCadastros.Models;
using System;
using System.Linq;
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

        [HttpGet]
        public IActionResult CadastroClientes()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CadastroClientes(Cliente model)
        {
            return await CadastrarEntidade(model, "Cliente", "CadastroClientes");
        }

        [HttpPost]
        public async Task<IActionResult> Cadastros(Produto model)
        {
            return await CadastrarEntidade(model, "Produto", "Cadastros");
        }

        /// <summary>
        /// Método genérico para cadastrar qualquer entidade (Produto ou Cliente)
        /// </summary>
        private async Task<IActionResult> CadastrarEntidade<T>(T model, string tipo, string viewName) where T : class
        {
            Console.WriteLine($"Método POST {viewName} foi chamado!");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("❌ ModelState inválido!");
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Erro: {error.ErrorMessage}");
                }
                TempData["MensagemErro"] = $"Preencha todos os campos corretamente para o {tipo}.";
                return View(viewName, model);
            }

            try
            {
                if (model is Cliente cliente)
                {
                    cliente.DataRegistro = DateTime.Now;
                    Console.WriteLine($"Dados Recebidos -> Nome: {cliente.NomeCliente}, CNPJ: {cliente.Cnpj}");
                    _context.Clientes.Add(cliente);
                }
                else if (model is Produto produto)
                {
                    produto.DataRegistro = DateTime.Now;
                    produto.Rua = (model as Produto).Rua; // Adiciona a Rua corretamente
                    Console.WriteLine($"Dados Recebidos -> Nome: {produto.NomeProduto}, Preço: {produto.Preco}, Rua: {produto.Rua}");
                    _context.Produtos.Add(produto);
                }

                Console.WriteLine("Salvando no banco...");
                var rowsAffected = await _context.SaveChangesAsync();

                if (rowsAffected > 0)
                {
                    Console.WriteLine($"{tipo} salvo com sucesso no banco!");
                }
                else
                {
                    Console.WriteLine("Nenhum registro foi salvo!");
                }

                TempData["MensagemSucesso"] = $"{tipo} cadastrado com sucesso!";
                TempData["TipoCadastro"] = tipo;
                return RedirectToAction("CadastroSucesso", "Cadastros");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message} | StackTrace: {ex.StackTrace}");
                TempData["MensagemErro"] = $"Erro ao cadastrar o {tipo}. Verifique o console.";
                return View(viewName, model);
            }
        }
    }
}
