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
using Accredi.Crm.ContactTelephones;

namespace Accredi.Crm.ContactTelephones
{

    [Authorize(CrmPermissions.ContactTelephones.Default)]
    public class ContactTelephonesAppService : CrmAppService, IContactTelephonesAppService
    {

        protected IContactTelephoneRepository _contactTelephoneRepository;
        protected ContactTelephoneManager _contactTelephoneManager;

        public ContactTelephonesAppService(IContactTelephoneRepository contactTelephoneRepository, ContactTelephoneManager contactTelephoneManager)
        {

            _contactTelephoneRepository = contactTelephoneRepository;
            _contactTelephoneManager = contactTelephoneManager;

        }

        public virtual async Task<PagedResultDto<ContactTelephoneDto>> GetListByContactIdAsync(GetContactTelephoneListInput input)
        {
            var contactTelephones = await _contactTelephoneRepository.GetListByContactIdAsync(
                input.ContactId,
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount);

            return new PagedResultDto<ContactTelephoneDto>
            {
                TotalCount = await _contactTelephoneRepository.GetCountByContactIdAsync(input.ContactId),
                Items = ObjectMapper.Map<List<ContactTelephone>, List<ContactTelephoneDto>>(contactTelephones)
            };
        }

        public virtual async Task<PagedResultDto<ContactTelephoneDto>> GetListAsync(GetContactTelephonesInput input)
        {
            var totalCount = await _contactTelephoneRepository.GetCountAsync(input.FilterText, input.Telephone, input.Type);
            var items = await _contactTelephoneRepository.GetListAsync(input.FilterText, input.Telephone, input.Type, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ContactTelephoneDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ContactTelephone>, List<ContactTelephoneDto>>(items)
            };
        }

        public virtual async Task<ContactTelephoneDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ContactTelephone, ContactTelephoneDto>(await _contactTelephoneRepository.GetAsync(id));
        }

        [Authorize(CrmPermissions.ContactTelephones.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _contactTelephoneRepository.DeleteAsync(id);
        }

        [Authorize(CrmPermissions.ContactTelephones.Create)]
        public virtual async Task<ContactTelephoneDto> CreateAsync(ContactTelephoneCreateDto input)
        {

            var contactTelephone = await _contactTelephoneManager.CreateAsync(input.ContactId
            , input.Telephone, input.Type
            );

            return ObjectMapper.Map<ContactTelephone, ContactTelephoneDto>(contactTelephone);
        }

        [Authorize(CrmPermissions.ContactTelephones.Edit)]
        public virtual async Task<ContactTelephoneDto> UpdateAsync(Guid id, ContactTelephoneUpdateDto input)
        {

            var contactTelephone = await _contactTelephoneManager.UpdateAsync(
            id, input.ContactId
            , input.Telephone, input.Type
            );

            return ObjectMapper.Map<ContactTelephone, ContactTelephoneDto>(contactTelephone);
        }
    }
}