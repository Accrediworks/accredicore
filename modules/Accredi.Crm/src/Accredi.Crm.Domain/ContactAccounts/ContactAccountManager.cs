using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Accredi.Crm.ContactAccounts
{
    public class ContactAccountManager : DomainService
    {
        protected IContactAccountRepository _contactAccountRepository;

        public ContactAccountManager(IContactAccountRepository contactAccountRepository)
        {
            _contactAccountRepository = contactAccountRepository;
        }

        public virtual async Task<ContactAccount> CreateAsync(
        Guid contactId, Guid accountId, Guid contactLevelId)
        {
            Check.NotNull(accountId, nameof(accountId));
            Check.NotNull(contactLevelId, nameof(contactLevelId));

            var contactAccount = new ContactAccount(
             GuidGenerator.Create(),
             contactId, accountId, contactLevelId
             );

            return await _contactAccountRepository.InsertAsync(contactAccount);
        }

        public virtual async Task<ContactAccount> UpdateAsync(
            Guid id,
            Guid contactId, Guid accountId, Guid contactLevelId
        )
        {
            Check.NotNull(accountId, nameof(accountId));
            Check.NotNull(contactLevelId, nameof(contactLevelId));

            var contactAccount = await _contactAccountRepository.GetAsync(id);

            contactAccount.ContactId = contactId;
            contactAccount.AccountId = accountId;
            contactAccount.ContactLevelId = contactLevelId;

            return await _contactAccountRepository.UpdateAsync(contactAccount);
        }

    }
}