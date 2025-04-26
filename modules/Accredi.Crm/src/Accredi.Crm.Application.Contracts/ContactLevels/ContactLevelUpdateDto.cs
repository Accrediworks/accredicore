using Accredi.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Accredi.Crm.ContactLevels
{
    public class ContactLevelUpdateDto : IHasConcurrencyStamp
    {
        [Required]
        public string Name { get; set; } = null!;
        public ContactLevelType Type { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}