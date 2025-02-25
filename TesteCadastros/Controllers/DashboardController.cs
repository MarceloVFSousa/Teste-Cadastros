using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TesteCadastros.Data;
using TesteCadastros.ViewModels;
using X.PagedList;
using X.PagedList.Extensions;
using X.PagedList.Mvc.Core;

namespace TesteCadastros.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return RedirectToAction("Dashboard");
        }

        public async Task<IActionResult> Dashboard(int? paginaProdutos, int? paginaClientes)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }

            int itensPorPagina = 10; // Define 10 registros por página

            // Carregar os produtos do banco
            var produtos = await _context.Produtos
                .OrderBy(p => p.NomeProduto)
                .Select(p => new ProdutoViewModel
                {
                    NomeProduto = p.NomeProduto,
                    Preco = p.Preco,
                    DataRegistro = p.DataRegistro,
                    DataPrevisao = p.DataPrevisao,
                    Cidade = p.Cidade,
                    Estado = p.Estado,
                    Cep = p.Cep
                })
                .ToListAsync(); // Converte para List antes da paginação

            // Carregar os clientes do banco
            var clientes = await _context.Clientes
                .OrderBy(c => c.NomeCliente)
                .Select(c => new ClienteViewModel
                {
                    NomeCliente = c.NomeCliente,
                    CNPJ = c.Cnpj,
                    DataRegistro = c.DataRegistro,
                    Cidade = c.Cidade,
                    Estado = c.Estado,
                    RamoDeAtividade = c.RamoDeAtividade
                })
                .ToListAsync(); // Converte para List antes da paginação

            // Aplicando a paginação (usando ToPagedList, e não ToPagedListAsync)
            var produtosPaginados = produtos.ToPagedList(paginaProdutos ?? 1, itensPorPagina);
            var clientesPaginados = clientes.ToPagedList(paginaClientes ?? 1, itensPorPagina);

            // Criar o objeto DashboardViewModel
            var dashboardViewModel = new DashboardViewModel
            {
                Produtos = produtosPaginados,
                Clientes = clientesPaginados
            };

            // Retornar a View correta dentro de Views/Home/
            return View("~/Views/Home/Dashboard.cshtml", dashboardViewModel);
        }
    }
}
