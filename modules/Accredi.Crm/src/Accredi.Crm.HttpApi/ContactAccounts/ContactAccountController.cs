using Accredi.Crm.Shared;
using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Accredi.Crm.ContactAccounts;

namespace Accredi.Crm.ContactAccounts
{
    [RemoteService(Name = "Crm")]
    [Area("crm")]
    [ControllerName("ContactAccount")]
    [Route("api/crm/contact-accounts")]
    public class ContactAccountController : AbpController, IContactAccountsAppService
    {
        protected IContactAccountsAppService _contactAccountsAppService;

        public ContactAccountController(IContactAccountsAppService contactAccountsAppService)
        {
            _contactAccountsAppService = contactAccountsAppService;
        }

        [HttpGet]
        [Route("by-contact")]
        public virtual Task<PagedResultDto<ContactAccountDto>> GetListByContactIdAsync(GetContactAccountListInput input)
        {
            return _contactAccountsAppService.GetListByContactIdAsync(input);
        }
        [HttpGet]
        [Route("detailed/by-contact")]
        public virtual Task<PagedResultDto<ContactAccountWithNavigationPropertiesDto>> GetListWithNavigationPropertiesByContactIdAsync(GetContactAccountListInput input)
        {
            return _contactAccountsAppService.GetListWithNavigationPropertiesByContactIdAsync(input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ContactAccountWithNavigationPropertiesDto>> GetListAsync(GetContactAccountsInput input)
        {
            return _contactAccountsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public virtual Task<ContactAccountWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _contactAccountsAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ContactAccountDto> GetAsync(Guid id)
        {
            return _contactAccountsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("account-lookup")]
        public virtual Task<PagedResultDto<LookupDto<Guid>>> GetAccountLookupAsync(LookupRequestDto input)
        {
            return _contactAccountsAppService.GetAccountLookupAsync(input);
        }

        [HttpGet]
        [Route("contact-level-lookup")]
        public virtual Task<PagedResultDto<LookupDto<Guid>>> GetContactLevelLookupAsync(LookupRequestDto input)
        {
            return _contactAccountsAppService.GetContactLevelLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<ContactAccountDto> CreateAsync(ContactAccountCreateDto input)
        {
            return _contactAccountsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ContactAccountDto> UpdateAsync(Guid id, ContactAccountUpdateDto input)
        {
            return _contactAccountsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _contactAccountsAppService.DeleteAsync(id);
        }
    }
}