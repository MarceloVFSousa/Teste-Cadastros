using System.ComponentModel.DataAnnotations;

namespace TesteCadastros.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Informe o e-mail ou nome de usuário.")]
        [Display(Name = "E-mail ou Nome de Usuário")]
        public string UsernameOrEmail { get; set; }

        [Required(ErrorMessage = "Informe a senha.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Lembrar-me?")]
        public bool RememberMe { get; set; }
    }
}
