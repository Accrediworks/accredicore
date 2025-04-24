using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Accredi.Crm.ContactTelephones;

namespace Accredi.Crm.ContactTelephones
{
    [RemoteService(Name = "Crm")]
    [Area("crm")]
    [ControllerName("ContactTelephone")]
    [Route("api/crm/contact-telephones")]
    public class ContactTelephoneController : AbpController, IContactTelephonesAppService
    {
        protected IContactTelephonesAppService _contactTelephonesAppService;

        public ContactTelephoneController(IContactTelephonesAppService contactTelephonesAppService)
        {
            _contactTelephonesAppService = contactTelephonesAppService;
        }

        [HttpGet]
        [Route("by-contact")]
        public virtual Task<PagedResultDto<ContactTelephoneDto>> GetListByContactIdAsync(GetContactTelephoneListInput input)
        {
            return _contactTelephonesAppService.GetListByContactIdAsync(input);
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ContactTelephoneDto>> GetListAsync(GetContactTelephonesInput input)
        {
            return _contactTelephonesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ContactTelephoneDto> GetAsync(Guid id)
        {
            return _contactTelephonesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ContactTelephoneDto> CreateAsync(ContactTelephoneCreateDto input)
        {
            return _contactTelephonesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ContactTelephoneDto> UpdateAsync(Guid id, ContactTelephoneUpdateDto input)
        {
            return _contactTelephonesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _contactTelephonesAppService.DeleteAsync(id);
        }
    }
}