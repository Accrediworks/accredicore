using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Accredi.Crm.Countries
{
    public class CountryManager : DomainService
    {
        protected ICountryRepository _countryRepository;

        public CountryManager(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public virtual async Task<Country> CreateAsync(
        string name, string iSO2Code, string iSO3Code)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(iSO2Code, nameof(iSO2Code));
            Check.NotNullOrWhiteSpace(iSO3Code, nameof(iSO3Code));

            var country = new Country(
             GuidGenerator.Create(),
             name, iSO2Code, iSO3Code
             );

            return await _countryRepository.InsertAsync(country);
        }

        public virtual async Task<Country> UpdateAsync(
            Guid id,
            string name, string iSO2Code, string iSO3Code, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNullOrWhiteSpace(iSO2Code, nameof(iSO2Code));
            Check.NotNullOrWhiteSpace(iSO3Code, nameof(iSO3Code));

            var country = await _countryRepository.GetAsync(id);

            country.Name = name;
            country.ISO2Code = iSO2Code;
            country.ISO3Code = iSO3Code;

            country.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _countryRepository.UpdateAsync(country);
        }

    }
}