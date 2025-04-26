using Accredi.Crm.Accounts;
using Accredi.Crm.ContactLevels;

using System;
using System.Collections.Generic;

namespace Accredi.Crm.ContactAccounts
{
    public  class ContactAccountWithNavigationProperties
    {
        public ContactAccount ContactAccount { get; set; } = null!;

        public Account Account { get; set; } = null!;
        public ContactLevel ContactLevel { get; set; } = null!;
        

        
    }
}