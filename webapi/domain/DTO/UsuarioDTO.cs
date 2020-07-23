using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class UsuarioLoginDTO
    {
        [Required(ErrorMessage = "O Username é obrigatório")]
        public string Username { get; set; }

        [Required(ErrorMessage = "O Password é obrigatório")]
        public string Password { get; set; }
    }
}
