using Accredi.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Accredi.Crm.ContactEmails
{
    public class ContactEmailUpdateDto
    {
        public Guid ContactId { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public ContactEmailType Type { get; set; }

    }
}