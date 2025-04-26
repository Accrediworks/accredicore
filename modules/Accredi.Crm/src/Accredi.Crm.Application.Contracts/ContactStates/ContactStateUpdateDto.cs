using Accredi.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Accredi.Crm.ContactStates
{
    public class ContactStateUpdateDto : IHasConcurrencyStamp
    {
        [Required]
        public string Name { get; set; } = null!;
        public ContactStateType Type { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}