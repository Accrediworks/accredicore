using Accredi.Crm.ContactStates;

using System;
using System.Collections.Generic;

namespace Accredi.Crm.Contacts
{
    public  class ContactWithNavigationProperties
    {
        public Contact Contact { get; set; } = null!;

        public ContactState ContactState { get; set; } = null!;
        

        
    }
}