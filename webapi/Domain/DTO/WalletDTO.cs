using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    #region Response



    #endregion

    #region Request

    public class WalletFormDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "O valor inicial da conta é obrigatório!")]
        public decimal Balance { get; set; }

        [Required(ErrorMessage = "O nome da conta é obrigatório!")]
        public string Name { get; set; }
    }

    #endregion
}
