namespace TesteCadastros.ViewModels
{
    public class ClienteViewModel
    {
        public int Id { get; set; }
        public string NomeCliente { get; set; }
        public string CNPJ { get; set; }
        public DateTime DataRegistro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string RamoDeAtividade { get; set; }
    }
}
