using Accredi.Crm.Shared;
using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Accredi.Crm.Contacts;

namespace Accredi.Crm.Contacts
{
    [RemoteService(Name = "Crm")]
    [Area("crm")]
    [ControllerName("Contact")]
    [Route("api/crm/contacts")]
    public class ContactController : AbpController, IContactsAppService
    {
        protected IContactsAppService _contactsAppService;

        public ContactController(IContactsAppService contactsAppService)
        {
            _contactsAppService = contactsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ContactWithNavigationPropertiesDto>> GetListAsync(GetContactsInput input)
        {
            return _contactsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("with-navigation-properties/{id}")]
        public virtual Task<ContactWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return _contactsAppService.GetWithNavigationPropertiesAsync(id);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ContactDto> GetAsync(Guid id)
        {
            return _contactsAppService.GetAsync(id);
        }

        [HttpGet]
        [Route("contact-state-lookup")]
        public virtual Task<PagedResultDto<LookupDto<Guid>>> GetContactStateLookupAsync(LookupRequestDto input)
        {
            return _contactsAppService.GetContactStateLookupAsync(input);
        }

        [HttpGet]
        [Route("contact-level-lookup")]
        public virtual Task<PagedResultDto<LookupDto<Guid>>> GetContactLevelLookupAsync(LookupRequestDto input)
        {
            return _contactsAppService.GetContactLevelLookupAsync(input);
        }

        [HttpGet]
        [Route("account-lookup")]
        public virtual Task<PagedResultDto<LookupDto<Guid>>> GetAccountLookupAsync(LookupRequestDto input)
        {
            return _contactsAppService.GetAccountLookupAsync(input);
        }

        [HttpPost]
        public virtual Task<ContactDto> CreateAsync(ContactCreateDto input)
        {
            return _contactsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ContactDto> UpdateAsync(Guid id, ContactUpdateDto input)
        {
            return _contactsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _contactsAppService.DeleteAsync(id);
        }
    }
}