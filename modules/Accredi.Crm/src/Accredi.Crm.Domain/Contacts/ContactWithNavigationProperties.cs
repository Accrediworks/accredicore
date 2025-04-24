using Accredi.Crm.ContactStates;
using Accredi.Crm.ContactLevels;
using Accredi.Crm.Accounts;

using System;
using System.Collections.Generic;

namespace Accredi.Crm.Contacts
{
    public  class ContactWithNavigationProperties
    {
        public Contact Contact { get; set; } = null!;

        public ContactState ContactState { get; set; } = null!;
        public ContactLevel ContactLevel { get; set; } = null!;
        

        public List<Account> Accounts { get; set; } = null!;
        
    }
}