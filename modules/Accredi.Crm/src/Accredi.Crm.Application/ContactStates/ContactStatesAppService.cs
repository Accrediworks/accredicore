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
using Accredi.Crm.ContactStates;

namespace Accredi.Crm.ContactStates
{

    [Authorize(CrmPermissions.ContactStates.Default)]
    public class ContactStatesAppService : CrmAppService, IContactStatesAppService
    {

        protected IContactStateRepository _contactStateRepository;
        protected ContactStateManager _contactStateManager;

        public ContactStatesAppService(IContactStateRepository contactStateRepository, ContactStateManager contactStateManager)
        {

            _contactStateRepository = contactStateRepository;
            _contactStateManager = contactStateManager;

        }

        public virtual async Task<PagedResultDto<ContactStateDto>> GetListAsync(GetContactStatesInput input)
        {
            var totalCount = await _contactStateRepository.GetCountAsync(input.FilterText, input.Name, input.Type);
            var items = await _contactStateRepository.GetListAsync(input.FilterText, input.Name, input.Type, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ContactStateDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ContactState>, List<ContactStateDto>>(items)
            };
        }

        public virtual async Task<ContactStateDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ContactState, ContactStateDto>(await _contactStateRepository.GetAsync(id));
        }

        [Authorize(CrmPermissions.ContactStates.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _contactStateRepository.DeleteAsync(id);
        }

        [Authorize(CrmPermissions.ContactStates.Create)]
        public virtual async Task<ContactStateDto> CreateAsync(ContactStateCreateDto input)
        {

            var contactState = await _contactStateManager.CreateAsync(
            input.Name, input.Type
            );

            return ObjectMapper.Map<ContactState, ContactStateDto>(contactState);
        }

        [Authorize(CrmPermissions.ContactStates.Edit)]
        public virtual async Task<ContactStateDto> UpdateAsync(Guid id, ContactStateUpdateDto input)
        {

            var contactState = await _contactStateManager.UpdateAsync(
            id,
            input.Name, input.Type, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<ContactState, ContactStateDto>(contactState);
        }
    }
}