using Accredi.Crm;
using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Accredi.Crm.ContactStates
{
    public class ContactStateCreateDto
    {
        [Required]
        public string Name { get; set; } = null!;
        public ContactStateType Type { get; set; } = ((ContactStateType[])Enum.GetValues(typeof(ContactStateType)))[0];
    }
}