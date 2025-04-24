using Accredi.Crm.ContactStates;
using Accredi.Crm.ContactLevels;
using Accredi.Crm.Accounts;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace Accredi.Crm.Contacts
{
    public class ContactWithNavigationPropertiesDto
    {
        public ContactDto Contact { get; set; } = null!;

        public ContactStateDto ContactState { get; set; } = null!;
        public ContactLevelDto ContactLevel { get; set; } = null!;
        public List<AccountDto> Accounts { get; set; } = new List<AccountDto>();

    }
}