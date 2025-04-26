using Accredi.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Accredi.Crm.ContactTelephones
{
    public class ContactTelephoneCreateDto
    {
        public Guid ContactId { get; set; }
        [Required]
        public string Telephone { get; set; } = null!;
        public ContactTelephoneType Type { get; set; } = ((ContactTelephoneType[])Enum.GetValues(typeof(ContactTelephoneType)))[0];
    }
}