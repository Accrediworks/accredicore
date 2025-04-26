using Accredi.Crm.Shared;
using Accredi.Crm.ContactLevels;
using Accredi.Crm.Accounts;
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
using Accredi.Crm.ContactAccounts;

namespace Accredi.Crm.ContactAccounts
{

    [Authorize(CrmPermissions.ContactAccounts.Default)]
    public class ContactAccountsAppService : CrmAppService, IContactAccountsAppService
    {

        protected IContactAccountRepository _contactAccountRepository;
        protected ContactAccountManager _contactAccountManager;

        protected IRepository<Accredi.Crm.Accounts.Account, Guid> _accountRepository;
        protected IRepository<Accredi.Crm.ContactLevels.ContactLevel, Guid> _contactLevelRepository;

        public ContactAccountsAppService(IContactAccountRepository contactAccountRepository, ContactAccountManager contactAccountManager, IRepository<Accredi.Crm.Accounts.Account, Guid> accountRepository, IRepository<Accredi.Crm.ContactLevels.ContactLevel, Guid> contactLevelRepository)
        {

            _contactAccountRepository = contactAccountRepository;
            _contactAccountManager = contactAccountManager; _accountRepository = accountRepository;
            _contactLevelRepository = contactLevelRepository;

        }

        public virtual async Task<PagedResultDto<ContactAccountDto>> GetListByContactIdAsync(GetContactAccountListInput input)
        {
            var contactAccounts = await _contactAccountRepository.GetListByContactIdAsync(
                input.ContactId,
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount);

            return new PagedResultDto<ContactAccountDto>
            {
                TotalCount = await _contactAccountRepository.GetCountByContactIdAsync(input.ContactId),
                Items = ObjectMapper.Map<List<ContactAccount>, List<ContactAccountDto>>(contactAccounts)
            };
        }
        public virtual async Task<PagedResultDto<ContactAccountWithNavigationPropertiesDto>> GetListWithNavigationPropertiesByContactIdAsync(GetContactAccountListInput input)
        {
            var contactAccounts = await _contactAccountRepository.GetListWithNavigationPropertiesByContactIdAsync(
                input.ContactId,
                input.Sorting,
                input.MaxResultCount,
                input.SkipCount);

            return new PagedResultDto<ContactAccountWithNavigationPropertiesDto>
            {
                TotalCount = await _contactAccountRepository.GetCountByContactIdAsync(input.ContactId),
                Items = ObjectMapper.Map<List<ContactAccountWithNavigationProperties>, List<ContactAccountWithNavigationPropertiesDto>>(contactAccounts)
            };
        }

        public virtual async Task<PagedResultDto<ContactAccountWithNavigationPropertiesDto>> GetListAsync(GetContactAccountsInput input)
        {
            var totalCount = await _contactAccountRepository.GetCountAsync(input.FilterText, input.AccountId, input.ContactLevelId);
            var items = await _contactAccountRepository.GetListWithNavigationPropertiesAsync(input.FilterText, input.AccountId, input.ContactLevelId, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<ContactAccountWithNavigationPropertiesDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<ContactAccountWithNavigationProperties>, List<ContactAccountWithNavigationPropertiesDto>>(items)
            };
        }

        public virtual async Task<ContactAccountWithNavigationPropertiesDto> GetWithNavigationPropertiesAsync(Guid id)
        {
            return ObjectMapper.Map<ContactAccountWithNavigationProperties, ContactAccountWithNavigationPropertiesDto>
                (await _contactAccountRepository.GetWithNavigationPropertiesAsync(id));
        }

        public virtual async Task<ContactAccountDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<ContactAccount, ContactAccountDto>(await _contactAccountRepository.GetAsync(id));
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetAccountLookupAsync(LookupRequestDto input)
        {
            var query = (await _accountRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Accredi.Crm.Accounts.Account>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Accredi.Crm.Accounts.Account>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        public virtual async Task<PagedResultDto<LookupDto<Guid>>> GetContactLevelLookupAsync(LookupRequestDto input)
        {
            var query = (await _contactLevelRepository.GetQueryableAsync())
                .WhereIf(!string.IsNullOrWhiteSpace(input.Filter),
                    x => x.Name != null &&
                         x.Name.Contains(input.Filter));

            var lookupData = await query.PageBy(input.SkipCount, input.MaxResultCount).ToDynamicListAsync<Accredi.Crm.ContactLevels.ContactLevel>();
            var totalCount = query.Count();
            return new PagedResultDto<LookupDto<Guid>>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Accredi.Crm.ContactLevels.ContactLevel>, List<LookupDto<Guid>>>(lookupData)
            };
        }

        [Authorize(CrmPermissions.ContactAccounts.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _contactAccountRepository.DeleteAsync(id);
        }

        [Authorize(CrmPermissions.ContactAccounts.Create)]
        public virtual async Task<ContactAccountDto> CreateAsync(ContactAccountCreateDto input)
        {
            if (input.AccountId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Account"]]);
            }
            if (input.ContactLevelId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["ContactLevel"]]);
            }

            var contactAccount = await _contactAccountManager.CreateAsync(input.ContactId
            , input.AccountId, input.ContactLevelId
            );

            return ObjectMapper.Map<ContactAccount, ContactAccountDto>(contactAccount);
        }

        [Authorize(CrmPermissions.ContactAccounts.Edit)]
        public virtual async Task<ContactAccountDto> UpdateAsync(Guid id, ContactAccountUpdateDto input)
        {
            if (input.AccountId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["Account"]]);
            }
            if (input.ContactLevelId == default)
            {
                throw new UserFriendlyException(L["The {0} field is required.", L["ContactLevel"]]);
            }

            var contactAccount = await _contactAccountManager.UpdateAsync(
            id, input.ContactId
            , input.AccountId, input.ContactLevelId
            );

            return ObjectMapper.Map<ContactAccount, ContactAccountDto>(contactAccount);
        }
    }
}