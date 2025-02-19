namespace TesteCadastros.ViewModels
{
    public class ProdutoViewModel
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public string Preco { get; set; }
        public DateTime DataRegistro { get; set; }
        public DateTime DataPrevisao { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }
    }
}
