using Accredi.Crm.Accounts;
using Accredi.Crm.ContactLevels;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace Accredi.Crm.ContactAccounts
{
    public class ContactAccountWithNavigationPropertiesDto
    {
        public ContactAccountDto ContactAccount { get; set; } = null!;

        public AccountDto Account { get; set; } = null!;
        public ContactLevelDto ContactLevel { get; set; } = null!;

    }
}