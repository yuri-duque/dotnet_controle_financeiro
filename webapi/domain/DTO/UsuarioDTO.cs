using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class UsuarioLoginDTO
    {
        [Required(ErrorMessage = "O username é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        public string Password { get; set; }
    }

    public class UsuarioCadastroDTO
    {
        [Required(ErrorMessage = "O username é obrigatório")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória")]
        [StringLength(16, ErrorMessage = "A senha deve ter entre 3 e 16 caracteres", MinimumLength = 3)]
        public string Password { get; set; }

        [Required(ErrorMessage = "A confirmação da senha é obrigatório")]
        [Compare("Password", ErrorMessage = "A confirmação da senha e a senha não conhecidem")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "O email é obrigatório")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "O email é inválido")]
        public string Mail { get; set; }
    }
}
