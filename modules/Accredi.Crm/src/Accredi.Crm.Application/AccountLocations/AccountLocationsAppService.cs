using Accredi.Crm.Shared;
using Accredi.Crm.Countries;
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
using Accredi.Crm.AccountLocations;

namespace Accredi.Crm.AccountLocations
{

    [Authorize(CrmPermissions.AccountLocations.Default)]
    public class AccountLocationsAppService : CrmAppService, IAccountLocationsAppService
    {

        protected IAccountLocationRepository _accountLocationRepository;
        protected AccountLocationManager _accountLocationManager;

        protected IRepository<Accredi.Crm.Countries.Country, Guid> _countryRepository;

        public AccountLocationsAppService(IAccountLocationRepository accountLocationRepository, AccountLocationManager accountLocationManager, IRepository<Accredi.Crm.Countries.Country, Guid> countryRepository)
        {

            _accountLocationRepository = accountLocationRepository;
            _accountLocationManager = accountLocationManager; _countryRepository = countryRepository;

        }

        public virtual async Task<PagedResultDto<AccountLocationDto>> GetListByAccountIdAsync(GetAccountLocationListInput input)
        {
            var accountLocations = await _accountLocationRepository.GetListByAccountIdAsync(
                input.AccountId,
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount);

            return new PagedResultDto<AccountLocationDto>
            {
                TotalCount = await _accountLocationRepository.GetCountByAccountIdAsync(input.AccountId),
                Items = ObjectMapper.Map<List<AccountLocation>, List<AccountLocationDto>>(accountLocations)
            };
        }
        public virtual async Task<PagedResultDto<AccountLocationWithNavigationPropertiesDto>> GetListWithNavigationPropertiesByAccountIdAsync(GetAccountLocationListInput input)
        {
            var accountLocations = await _accountLocationRepository.GetListWithNavigationPropertiesByAccountIdAsync(
                input.AccountId,
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount);

            return new PagedResultDto<AccountLocationWithNavigationPropertiesDto>
            {
                TotalCount = await _accountLocationRepository.GetCountByAccountIdAsync(input.AccountId),
                Items = ObjectMapper.Map<List<AccountLocationWithNavigationProperties>, List<AccountLocationWithNavigationPropertiesDto>>(accountLocations)
            };
        }

        public virtual async Task<PagedResultDto<AccountLocationWithNavigationPropertiesDto>> GetListAsync(GetAccountLocationsInput input)
        {
            var totalCount = await _accountLocationRepository.GetCountAsync(input.FilterText, input.Reference, input.CountryId);
            var items = await _accountLocationRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Reference, input.CountryId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AccountLocationWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<AccountLocationWithNavigationProperties>, List<AccountLocationWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<AccountLocationWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<AccountLocationWithNavigationProperties, AccountLocationWithNavigationPropertiesDto>
                (await _accountLocationRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<AccountLocationDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<AccountLocation, AccountLocationDto>(await _accountLocationRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            var query = (await _countryRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Accredi.Crm.Countries.Country>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Accredi.Crm.Countries.Country>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(CrmPermissions.AccountLocations.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _accountLocationRepository.DeleteAsync(id);
        }

        [Authorize(CrmPermissions.AccountLocations.Create)]
        public virtual async Task<AccountLocationDto> CreateAsync(AccountLocationCreateDto input)
        {
            if (input.CountryId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }

            var accountLocation = await _accountLocationManager.CreateAsync(input.AccountId
            , input.CountryId, input.Reference, input.Line1, input.Town, input.County, input.Postcode, input.Line2, input.Line3
            );

            return ObjectMapper.Map<AccountLocation, AccountLocationDto>(accountLocation);
        }

        [Authorize(CrmPermissions.AccountLocations.Edit)]
        public virtual async Task<AccountLocationDto> UpdateAsync(Guid id, AccountLocationUpdateDto input)
        {
            if (input.CountryId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Country"]]);
            }

            var accountLocation = await _accountLocationManager.UpdateAsync(
            id, input.AccountId
            , input.CountryId, input.Reference, input.Line1, input.Town, input.County, input.Postcode, input.Line2, input.Line3
            );

            return ObjectMapper.Map<AccountLocation, AccountLocationDto>(accountLocation);
        }
    }
}