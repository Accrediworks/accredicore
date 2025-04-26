using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Accredi.Crm.Accounts
{
    public class AccountManager : DomainService
    {
        protected IAccountRepository _accountRepository;

        public AccountManager(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public virtual async Task<Account> CreateAsync(
        string name)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var account = new Account(
             GuidGenerator.Create(),
             name
             );

            return await _accountRepository.InsertAsync(account);
        }

        public virtual async Task<Account> UpdateAsync(
            Guid id,
            string name, string? taxReference = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));

            var account = await _accountRepository.GetAsync(id);

            account.Name = name;
            account.TaxReference = taxReference;

            account.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _accountRepository.UpdateAsync(account);
        }

    }
}