﻿using System.ComponentModel.DataAnnotations;

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
        public string DataRegistro { get; set; }
        [Required]
        public string DataPrevisao { get; set; }
        [Required]
        public string Cidade { get; set; }
        [Required]
        public string Estado { get; set; }
        [Required]
        public string Cep { get; set; }



    }
}
