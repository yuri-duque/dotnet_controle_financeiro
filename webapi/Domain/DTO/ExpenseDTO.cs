using System;

namespace Domain.DTO
{
    public class ExpenseListDTO
    {
        public long Id { get; set; }

        public DateTime DateRegister { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }
    }
}
