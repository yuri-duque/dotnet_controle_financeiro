using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class IncomeListDTO
    {
        public long Id { get; set; }

        public DateTime DateRegister { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }
    }
}
