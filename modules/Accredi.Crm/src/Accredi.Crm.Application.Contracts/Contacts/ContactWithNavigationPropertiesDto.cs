using Accredi.Crm.ContactStates;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace Accredi.Crm.Contacts
{
    public class ContactWithNavigationPropertiesDto
    {
        public ContactDto Contact { get; set; } = null!;

        public ContactStateDto ContactState { get; set; } = null!;

    }
}