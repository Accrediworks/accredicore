using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Accredi.Crm.Accounts
{
    public class AccountCreateDto
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}