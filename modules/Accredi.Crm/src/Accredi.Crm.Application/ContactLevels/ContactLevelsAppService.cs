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
using Accredi.Crm.ContactLevels;

namespace Accredi.Crm.ContactLevels
{

    [Authorize(CrmPermissions.ContactLevels.Default)]
    public class ContactLevelsAppService : CrmAppService, IContactLevelsAppService
    {

        protected IContactLevelRepository _contactLevelRepository;
        protected ContactLevelManager _contactLevelManager;

        public ContactLevelsAppService(IContactLevelRepository contactLevelRepository, ContactLevelManager contactLevelManager)
        {

            _contactLevelRepository = contactLevelRepository;
            _contactLevelManager = contactLevelManager;

        }

        public virtual async Task<PagedResultDto<ContactLevelDto>> GetListAsync(GetContactLevelsInput input)
        {
            var totalCount = await _contactLevelRepository.GetCountAsync(input.FilterText, input.Name, input.Type);
            var items = await _contactLevelRepository.GetListAsync(input.FilterText, input.Name, input.Type, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ContactLevelDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ContactLevel>, List<ContactLevelDto>>(items)
            };
        }

        public virtual async Task<ContactLevelDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ContactLevel, ContactLevelDto>(await _contactLevelRepository.GetAsync(id));
        }

        [Authorize(CrmPermissions.ContactLevels.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _contactLevelRepository.DeleteAsync(id);
        }

        [Authorize(CrmPermissions.ContactLevels.Create)]
        public virtual async Task<ContactLevelDto> CreateAsync(ContactLevelCreateDto input)
        {

            var contactLevel = await _contactLevelManager.CreateAsync(
            input.Name, input.Type
            );

            return ObjectMapper.Map<ContactLevel, ContactLevelDto>(contactLevel);
        }

        [Authorize(CrmPermissions.ContactLevels.Edit)]
        public virtual async Task<ContactLevelDto> UpdateAsync(Guid id, ContactLevelUpdateDto input)
        {

            var contactLevel = await _contactLevelManager.UpdateAsync(
            id,
            input.Name, input.Type, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<ContactLevel, ContactLevelDto>(contactLevel);
        }
    }
}