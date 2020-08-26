using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.DTO
{
    public class ExpenseListDTO
    {
        public long Id { get; set; }

        public DateTime DateRegister { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }
    }

    public class ExpenseFormDTO
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "A data de registro é obrigatória")]
        public DateTime DateRegister { get; set; }

        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Description { get; set; }

        [Required(ErrorMessage = "O valor é obrigatório")]
        public decimal Value { get; set; }

        [Required(ErrorMessage = "O id da carteira é obrigatória")]
        public long IdWallet { get; set; }
    }
}
