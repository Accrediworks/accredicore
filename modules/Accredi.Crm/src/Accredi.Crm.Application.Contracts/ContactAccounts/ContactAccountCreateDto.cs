using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Accredi.Crm.ContactAccounts
{
    public class ContactAccountCreateDto
    {
        public Guid ContactId { get; set; }
        public Guid AccountId { get; set; }
        public Guid ContactLevelId { get; set; }
    }
}