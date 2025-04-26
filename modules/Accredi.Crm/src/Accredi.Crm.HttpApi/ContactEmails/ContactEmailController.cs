using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Accredi.Crm.ContactEmails;

namespace Accredi.Crm.ContactEmails
{
    [RemoteService(Name = "Crm")]
    [Area("crm")]
    [ControllerName("ContactEmail")]
    [Route("api/crm/contact-emails")]
    public class ContactEmailController : AbpController, IContactEmailsAppService
    {
        protected IContactEmailsAppService _contactEmailsAppService;

        public ContactEmailController(IContactEmailsAppService contactEmailsAppService)
        {
            _contactEmailsAppService = contactEmailsAppService;
        }

        [HttpGet]
        [Route("by-contact")]
        public virtual Task<PagedResultDto<ContactEmailDto>> GetListByContactIdAsync(GetContactEmailListInput input)
        {
            return _contactEmailsAppService.GetListByContactIdAsync(input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ContactEmailDto>> GetListAsync(GetContactEmailsInput input)
        {
            return _contactEmailsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ContactEmailDto> GetAsync(Guid id)
        {
            return _contactEmailsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ContactEmailDto> CreateAsync(ContactEmailCreateDto input)
        {
            return _contactEmailsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ContactEmailDto> UpdateAsync(Guid id, ContactEmailUpdateDto input)
        {
            return _contactEmailsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _contactEmailsAppService.DeleteAsync(id);
        }
    }
}