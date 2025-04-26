using Accredi.Crm.Shared;
using Accredi.Crm.ContactStates;
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
using Accredi.Crm.Contacts;

namespace Accredi.Crm.Contacts
{

    [Authorize(CrmPermissions.Contacts.Default)]
    public class ContactsAppService : CrmAppService, IContactsAppService
    {

        protected IContactRepository _contactRepository;
        protected ContactManager _contactManager;

        protected IRepository<Accredi.Crm.ContactStates.ContactState, Guid> _contactStateRepository;

        public ContactsAppService(IContactRepository contactRepository, ContactManager contactManager, IRepository<Accredi.Crm.ContactStates.ContactState, Guid> contactStateRepository)
        {

            _contactRepository = contactRepository;
            _contactManager = contactManager; _contactStateRepository = contactStateRepository;

        }

        public virtual async Task<PagedResultDto<ContactWithNavigationPropertiesDto>> GetListAsync(GetContactsInput input)
        {
            var totalCount = await _contactRepository.GetCountAsync(input.FilterText, input.Reference, input.FirstName, input.LastName, input.NationalIdentifier, input.DateOfBirthMin, input.DateOfBirthMax, input.ContactStateId);
            var items = await _contactRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.Reference, input.FirstName, input.LastName, input.NationalIdentifier, input.DateOfBirthMin, input.DateOfBirthMax, input.ContactStateId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ContactWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ContactWithNavigationProperties>, List<ContactWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<ContactWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<ContactWithNavigationProperties, ContactWithNavigationPropertiesDto>
                (await _contactRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<ContactDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Contact, ContactDto>(await _contactRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetContactStateLookupAsync(LookupRequestDto input)
        {
            var query = (await _contactStateRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Accredi.Crm.ContactStates.ContactState>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Accredi.Crm.ContactStates.ContactState>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(CrmPermissions.Contacts.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _contactRepository.DeleteAsync(id);
        }

        [Authorize(CrmPermissions.Contacts.Create)]
        public virtual async Task<ContactDto> CreateAsync(ContactCreateDto input)
        {
            if (input.ContactStateId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["ContactState"]]);
            }

            var contact = await _contactManager.CreateAsync(
            input.ContactStateId, input.Reference, input.FirstName, input.LastName, input.Title, input.MiddleName, input.NationalIdentifier, input.DateOfBirth
            );

            return ObjectMapper.Map<Contact, ContactDto>(contact);
        }

        [Authorize(CrmPermissions.Contacts.Edit)]
        public virtual async Task<ContactDto> UpdateAsync(Guid id, ContactUpdateDto input)
        {
            if (input.ContactStateId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["ContactState"]]);
            }

            var contact = await _contactManager.UpdateAsync(
            id,
            input.ContactStateId, input.Reference, input.FirstName, input.LastName, input.Title, input.MiddleName, input.NationalIdentifier, input.DateOfBirth, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Contact, ContactDto>(contact);
        }
    }
}