using X.PagedList;

namespace TesteCadastros.ViewModels
{
    public class DashboardViewModel
    {
        public IPagedList<ProdutoViewModel> Produtos { get; set; } // ✅ Modificado para IPagedList
        public IPagedList<ClienteViewModel> Clientes { get; set; } // ✅ Modificado para IPagedList

    }
}
