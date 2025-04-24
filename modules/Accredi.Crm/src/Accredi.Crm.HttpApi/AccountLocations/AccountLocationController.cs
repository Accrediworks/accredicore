using Accredi.Crm.Shared;
using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Accredi.Crm.AccountLocations;

namespace Accredi.Crm.AccountLocations
{
    [RemoteService(Name = "Crm")]
    [Area("crm")]
    [ControllerName("AccountLocation")]
    [Route("api/crm/account-locations")]
    public class AccountLocationController : AbpController, IAccountLocationsAppService
    {
        protected IAccountLocationsAppService _accountLocationsAppService;

        public AccountLocationController(IAccountLocationsAppService accountLocationsAppService)
        {
            _accountLocationsAppService = accountLocationsAppService;
        }

        [HttpGet]
        [Route("by-account")]
        public virtual Task<PagedResultDto<AccountLocationDto>> GetListByAccountIdAsync(GetAccountLocationListInput input)
        {
            return _accountLocationsAppService.GetListByAccountIdAsync(input);
        }
        [HttpGet]
        [Route("detailed/by-account")]
        public virtual Task<PagedResultDto<AccountLocationWithNavigationPropertiesDto>> GetListWithNavigationPropertiesByAccountIdAsync(GetAccountLocationListInput input)
        {
            return _accountLocationsAppService.GetListWithNavigationPropertiesByAccountIdAsync(input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<AccountLocationWithNavigationPropertiesDto>> GetListAsync(GetAccountLocationsInput input)
        {
            return _accountLocationsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public virtual Task<AccountLocationWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _accountLocationsAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<AccountLocationDto> GetAsync(Guid id)
        {
            return _accountLocationsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("country-lookup")]
        public virtual Task<PagedResultDto<LookupDto<Guid>>> GetCountryLookupAsync(LookupRequestDto input)
        {
            return _accountLocationsAppService.GetCountryLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<AccountLocationDto> CreateAsync(AccountLocationCreateDto input)
        {
            return _accountLocationsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<AccountLocationDto> UpdateAsync(Guid id, AccountLocationUpdateDto input)
        {
            return _accountLocationsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _accountLocationsAppService.DeleteAsync(id);
        }
    }
}