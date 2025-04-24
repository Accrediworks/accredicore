using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Accredi.Crm.Accounts
{
    public class AccountUpdateDto : IHasConcurrencyStamp
    {
        [Required]
        public string Name { get; set; } = null!;
        public string? TaxReference { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}