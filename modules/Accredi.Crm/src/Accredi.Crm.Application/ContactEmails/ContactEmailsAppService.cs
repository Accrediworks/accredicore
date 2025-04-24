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
using Accredi.Crm.ContactEmails;

namespace Accredi.Crm.ContactEmails
{

    [Authorize(CrmPermissions.ContactEmails.Default)]
    public class ContactEmailsAppService : CrmAppService, IContactEmailsAppService
    {

        protected IContactEmailRepository _contactEmailRepository;
        protected ContactEmailManager _contactEmailManager;

        public ContactEmailsAppService(IContactEmailRepository contactEmailRepository, ContactEmailManager contactEmailManager)
        {

            _contactEmailRepository = contactEmailRepository;
            _contactEmailManager = contactEmailManager;

        }

        public virtual async Task<PagedResultDto<ContactEmailDto>> GetListByContactIdAsync(GetContactEmailListInput input)
        {
            var contactEmails = await _contactEmailRepository.GetListByContactIdAsync(
                input.ContactId,
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount);

            return new PagedResultDto<ContactEmailDto>
            {
                TotalCount = await _contactEmailRepository.GetCountByContactIdAsync(input.ContactId),
                Items = ObjectMapper.Map<List<ContactEmail>, List<ContactEmailDto>>(contactEmails)
            };
        }

        public virtual async Task<PagedResultDto<ContactEmailDto>> GetListAsync(GetContactEmailsInput input)
        {
            var totalCount = await _contactEmailRepository.GetCountAsync(input.FilterText, input.Email, input.Type);
            var items = await _contactEmailRepository.GetListAsync(input.FilterText, input.Email, input.Type, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ContactEmailDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ContactEmail>, List<ContactEmailDto>>(items)
            };
        }

        public virtual async Task<ContactEmailDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ContactEmail, ContactEmailDto>(await _contactEmailRepository.GetAsync(id));
        }

        [Authorize(CrmPermissions.ContactEmails.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _contactEmailRepository.DeleteAsync(id);
        }

        [Authorize(CrmPermissions.ContactEmails.Create)]
        public virtual async Task<ContactEmailDto> CreateAsync(ContactEmailCreateDto input)
        {

            var contactEmail = await _contactEmailManager.CreateAsync(input.ContactId
            , input.Email, input.Type
            );

            return ObjectMapper.Map<ContactEmail, ContactEmailDto>(contactEmail);
        }

        [Authorize(CrmPermissions.ContactEmails.Edit)]
        public virtual async Task<ContactEmailDto> UpdateAsync(Guid id, ContactEmailUpdateDto input)
        {

            var contactEmail = await _contactEmailManager.UpdateAsync(
            id, input.ContactId
            , input.Email, input.Type
            );

            return ObjectMapper.Map<ContactEmail, ContactEmailDto>(contactEmail);
        }
    }
}