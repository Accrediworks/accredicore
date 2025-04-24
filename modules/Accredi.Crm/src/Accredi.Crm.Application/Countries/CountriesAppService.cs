using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Accredi.Crm.Permissions;
using Accredi.Crm.Countries;

namespace Accredi.Crm.Countries
{

    [Authorize(CrmPermissions.Countries.Default)]
    public class CountriesAppService : CrmAppService, ICountriesAppService
    {

        protected ICountryRepository _countryRepository;
        protected CountryManager _countryManager;

        public CountriesAppService(ICountryRepository countryRepository, CountryManager countryManager)
        {

            _countryRepository = countryRepository;
            _countryManager = countryManager;

        }

        public virtual async Task<PagedResultDto<CountryDto>> GetListAsync(GetCountriesInput input)
        {
            var totalCount = await _countryRepository.GetCountAsync(input.FilterText, input.Name, input.ISO2Code, input.ISO3Code);
            var items = await _countryRepository.GetListAsync(input.FilterText, input.Name, input.ISO2Code, input.ISO3Code, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<CountryDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Country>, List<CountryDto>>(items)
            };
        }

        public virtual async Task<CountryDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Country, CountryDto>(await _countryRepository.GetAsync(id));
        }

        [Authorize(CrmPermissions.Countries.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _countryRepository.DeleteAsync(id);
        }

        [Authorize(CrmPermissions.Countries.Create)]
        public virtual async Task<CountryDto> CreateAsync(CountryCreateDto input)
        {

            var country = await _countryManager.CreateAsync(
            input.Name, input.ISO2Code, input.ISO3Code
            );

            return ObjectMapper.Map<Country, CountryDto>(country);
        }

        [Authorize(CrmPermissions.Countries.Edit)]
        public virtual async Task<CountryDto> UpdateAsync(Guid id, CountryUpdateDto input)
        {

            var country = await _countryManager.UpdateAsync(
            id,
            input.Name, input.ISO2Code, input.ISO3Code, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Country, CountryDto>(country);
        }
    }
}