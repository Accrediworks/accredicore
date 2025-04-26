using Asp.Versioning;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Accredi.Crm.ContactLevels;

namespace Accredi.Crm.ContactLevels
{
    [RemoteService(Name = "Crm")]
    [Area("crm")]
    [ControllerName("ContactLevel")]
    [Route("api/crm/contact-levels")]
    public class ContactLevelController : AbpController, IContactLevelsAppService
    {
        protected IContactLevelsAppService _contactLevelsAppService;

        public ContactLevelController(IContactLevelsAppService contactLevelsAppService)
        {
            _contactLevelsAppService = contactLevelsAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<ContactLevelDto>> GetListAsync(GetContactLevelsInput input)
        {
            return _contactLevelsAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<ContactLevelDto> GetAsync(Guid id)
        {
            return _contactLevelsAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<ContactLevelDto> CreateAsync(ContactLevelCreateDto input)
        {
            return _contactLevelsAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<ContactLevelDto> UpdateAsync(Guid id, ContactLevelUpdateDto input)
        {
            return _contactLevelsAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(Guid id)
        {
            return _contactLevelsAppService.DeleteAsync(id);
        }
    }
}