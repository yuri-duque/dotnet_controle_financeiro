using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.DTO
{
    #region Response



    #endregion


    #region Request

    public class WalletFormDTO
    {
        public long Id { get; set; }

        [Required]
        public decimal Balance { get; set; }

        public long IdUser { get; set; }
    }

    #endregion
}
