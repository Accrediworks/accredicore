using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Accredi.Crm.ContactStates;

namespace Accredi.Crm.ContactStates
{
    [RemoteService(Name = "Crm")]
    [Area("crm")]
    [ControllerName("ContactState")]
    [Route("api/crm/contact-states")]
    public class ContactStateController : AbpController, IContactStatesAppService
    {
        protected IContactStatesAppService _contactStatesAppService;

        public ContactStateController(IContactStatesAppService contactStatesAppService)
        {
            _contactStatesAppService = contactStatesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ContactStateDto>> GetListAsync(GetContactStatesInput input)
        {
            return _contactStatesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ContactStateDto> GetAsync(Guid id)
        {
            return _contactStatesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ContactStateDto> CreateAsync(ContactStateCreateDto input)
        {
            return _contactStatesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ContactStateDto> UpdateAsync(Guid id, ContactStateUpdateDto input)
        {
            return _contactStatesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _contactStatesAppService.DeleteAsync(id);
        }
    }
}