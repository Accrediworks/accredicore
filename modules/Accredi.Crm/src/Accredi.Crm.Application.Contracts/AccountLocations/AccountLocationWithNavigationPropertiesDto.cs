using Accredi.Crm.Countries;

using System;
using Volo.Abp.Application.Dtos;
using System.Collections.Generic;

namespace Accredi.Crm.AccountLocations
{
    public class AccountLocationWithNavigationPropertiesDto
    {
        public AccountLocationDto AccountLocation { get; set; } = null!;

        public CountryDto Country { get; set; } = null!;

    }
}