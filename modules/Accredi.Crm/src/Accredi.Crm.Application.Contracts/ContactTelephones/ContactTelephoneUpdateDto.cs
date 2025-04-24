using Accredi.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Accredi.Crm.ContactTelephones
{
    public class ContactTelephoneUpdateDto
    {
        public Guid ContactId { get; set; }
        [Required]
        public string PhoneNumber { get; set; } = null!;
        public ContactTelephoneType Type { get; set; }

    }
}