using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Accredi.Crm.AccountLocations
{
    public class AccountLocationManager : DomainService
    {
        protected IAccountLocationRepository _accountLocationRepository;

        public AccountLocationManager(IAccountLocationRepository accountLocationRepository)
        {
            _accountLocationRepository = accountLocationRepository;
        }

        public virtual async Task<AccountLocation> CreateAsync(
        Guid accountId, Guid countryId, string reference, string line1, string town, string county, string postcode, string? line2 = null, string? line3 = null)
        {
            Check.NotNull(countryId, nameof(countryId));
            Check.NotNullOrWhiteSpace(reference, nameof(reference));
            Check.NotNullOrWhiteSpace(line1, nameof(line1));
            Check.NotNullOrWhiteSpace(town, nameof(town));
            Check.NotNullOrWhiteSpace(county, nameof(county));
            Check.NotNullOrWhiteSpace(postcode, nameof(postcode));

            var accountLocation = new AccountLocation(
             GuidGenerator.Create(),
             accountId, countryId, reference, line1, town, county, postcode, line2, line3
             );

            return await _accountLocationRepository.InsertAsync(accountLocation);
        }

        public virtual async Task<AccountLocation> UpdateAsync(
            Guid id,
            Guid accountId, Guid countryId, string reference, string line1, string town, string county, string postcode, string? line2 = null, string? line3 = null
        )
        {
            Check.NotNull(countryId, nameof(countryId));
            Check.NotNullOrWhiteSpace(reference, nameof(reference));
            Check.NotNullOrWhiteSpace(line1, nameof(line1));
            Check.NotNullOrWhiteSpace(town, nameof(town));
            Check.NotNullOrWhiteSpace(county, nameof(county));
            Check.NotNullOrWhiteSpace(postcode, nameof(postcode));

            var accountLocation = await _accountLocationRepository.GetAsync(id);

            accountLocation.AccountId = accountId;
            accountLocation.CountryId = countryId;
            accountLocation.Reference = reference;
            accountLocation.Line1 = line1;
            accountLocation.Town = town;
            accountLocation.County = county;
            accountLocation.Postcode = postcode;
            accountLocation.Line2 = line2;
            accountLocation.Line3 = line3;

            return await _accountLocationRepository.UpdateAsync(accountLocation);
        }

    }
}