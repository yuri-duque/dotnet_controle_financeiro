using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    #region Response

    public class WalletListDTO
    {
        public long Id { get; set; }

        public decimal Balance { get; set; }

        public string Name { get; set; }
    }

    #endregion

    #region Request

    public class WalletFormDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O valor inicial da carteira é obrigatório!")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "O nome da carteira é obrigatório!")]
        public string Name { get; set; }
    }

    #endregion
}
