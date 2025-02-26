using System.ComponentModel.DataAnnotations;

namespace TesteCadastros.Models
{
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeProduto { get; set; }
        [Required]
        public string Preco { get; set; }
        //[Required]
        public DateTime DataRegistro { get; set; }
        [Required]
        public DateTime DataPrevisao { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Cep { get; set; }
        public string Rua {  get; set; }

    }
}
