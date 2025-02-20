using System.ComponentModel.DataAnnotations;

namespace TesteCadastros.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string NomeCliente { get; set; }
        [Required]
        public string Cnpj { get; set; }
        //[Required]
        public DateTime DataRegistro { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string RamoDeAtividade { get; set; }



    }
}
