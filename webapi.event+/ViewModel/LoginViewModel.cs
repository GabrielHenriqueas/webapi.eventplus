using System.ComponentModel.DataAnnotations;

namespace webapi.event_.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email obrigatório!")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Senha obrigatório!")]
        public string? Senha { get; set; }
    }
}
