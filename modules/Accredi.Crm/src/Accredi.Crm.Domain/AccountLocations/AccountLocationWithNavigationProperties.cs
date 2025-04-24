using Accredi.Crm.Countries;

using System;
using System.Collections.Generic;

namespace Accredi.Crm.AccountLocations
{
    public  class AccountLocationWithNavigationProperties
    {
        public AccountLocation AccountLocation { get; set; } = null!;

        public Country Country { get; set; } = null!;
        

        
    }
}