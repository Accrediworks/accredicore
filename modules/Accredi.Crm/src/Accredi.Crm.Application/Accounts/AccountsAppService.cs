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
using Accredi.Crm.Accounts;

namespace Accredi.Crm.Accounts
{

    [Authorize(CrmPermissions.Accounts.Default)]
    public class AccountsAppService : CrmAppService, IAccountsAppService
    {

        protected IAccountRepository _accountRepository;
        protected AccountManager _accountManager;

        public AccountsAppService(IAccountRepository accountRepository, AccountManager accountManager)
        {

            _accountRepository = accountRepository;
            _accountManager = accountManager;

        }

        public virtual async Task<PagedResultDto<AccountDto>> GetListAsync(GetAccountsInput input)
        {
            var totalCount = await _accountRepository.GetCountAsync(input.FilterText, input.Name);
            var items = await _accountRepository.GetListAsync(input.FilterText, input.Name, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<AccountDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Account>, List<AccountDto>>(items)
            };
        }

        public virtual async Task<AccountDto> GetAsync(Guid id)
        {
            return ObjectMapper.Map<Account, AccountDto>(await _accountRepository.GetAsync(id));
        }

        [Authorize(CrmPermissions.Accounts.Delete)]
        public virtual async Task DeleteAsync(Guid id)
        {
            await _accountRepository.DeleteAsync(id);
        }

        [Authorize(CrmPermissions.Accounts.Create)]
        public virtual async Task<AccountDto> CreateAsync(AccountCreateDto input)
        {

            var account = await _accountManager.CreateAsync(
            input.Name
            );

            return ObjectMapper.Map<Account, AccountDto>(account);
        }

        [Authorize(CrmPermissions.Accounts.Edit)]
        public virtual async Task<AccountDto> UpdateAsync(Guid id, AccountUpdateDto input)
        {

            var account = await _accountManager.UpdateAsync(
            id,
            input.Name, input.TaxReference, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Account, AccountDto>(account);
        }
    }
}