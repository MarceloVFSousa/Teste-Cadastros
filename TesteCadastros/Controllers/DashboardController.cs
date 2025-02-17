using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TesteCadastros.Controllers
{
    [Authorize] // Garante que somente usuários autenticados acessem o Dashboard
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account"); // Se não estiver autenticado, volta para login
            }

            return View();
        }

    }
}
