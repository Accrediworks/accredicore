using Accredi.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Accredi.Crm.ContactLevels
{
    public class ContactLevelCreateDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public ContactLevelType Type { get; set; } = ((ContactLevelType[])Enum.GetValues(typeof(ContactLevelType)))[0];
    }
}