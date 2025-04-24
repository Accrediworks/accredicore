using Accredi.Crm.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Accredi.Crm.Contacts
{
    public class ContactManager : DomainService
    {
        protected IContactRepository _contactRepository;
        protected IRepository<Account, Guid> _accountRepository;

        public ContactManager(IContactRepository contactRepository,
        IRepository<Account, Guid> accountRepository)
        {
            _contactRepository = contactRepository;
            _accountRepository = accountRepository;
        }

        public virtual async Task<Contact> CreateAsync(
        List<Guid> accountIds,
        Guid contactStateId, Guid contactLevelId, string reference, string firstName, string lastName, string? title = null, string? middleName = null, string? nationalIdentifier = null, DateOnly? dateOfBirth = null)
        {
            Check.NotNull(contactStateId, nameof(contactStateId));
            Check.NotNull(contactLevelId, nameof(contactLevelId));
            Check.NotNullOrWhiteSpace(reference, nameof(reference));
            Check.NotNullOrWhiteSpace(firstName, nameof(firstName));
            Check.NotNullOrWhiteSpace(lastName, nameof(lastName));

            var contact = new Contact(
             GuidGenerator.Create(),
             contactStateId, contactLevelId, reference, firstName, lastName, title, middleName, nationalIdentifier, dateOfBirth
             );

            await SetAccountsAsync(contact, accountIds);

            return await _contactRepository.InsertAsync(contact);
        }

        public virtual async Task<Contact> UpdateAsync(
            Guid id,
            List<Guid> accountIds,
        Guid contactStateId, Guid contactLevelId, string reference, string firstName, string lastName, string? title = null, string? middleName = null, string? nationalIdentifier = null, DateOnly? dateOfBirth = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNull(contactStateId, nameof(contactStateId));
            Check.NotNull(contactLevelId, nameof(contactLevelId));
            Check.NotNullOrWhiteSpace(reference, nameof(reference));
            Check.NotNullOrWhiteSpace(firstName, nameof(firstName));
            Check.NotNullOrWhiteSpace(lastName, nameof(lastName));

            var queryable = await _contactRepository.WithDetailsAsync(x => x.Accounts);
            var query = queryable.Where(x => x.Id == id);

            var contact = await AsyncExecuter.FirstOrDefaultAsync(query);

            contact.ContactStateId = contactStateId;
            contact.ContactLevelId = contactLevelId;
            contact.Reference = reference;
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.Title = title;
            contact.MiddleName = middleName;
            contact.NationalIdentifier = nationalIdentifier;
            contact.DateOfBirth = dateOfBirth;

            await SetAccountsAsync(contact, accountIds);

            contact.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _contactRepository.UpdateAsync(contact);
        }

        private async Task SetAccountsAsync(Contact contact, List<Guid> accountIds)
        {
            if (accountIds == null || !accountIds.Any())
            {
                contact.RemoveAllAccounts();
                return;
            }

            var query = (await _accountRepository.GetQueryableAsync())
                .Where(x => accountIds.Contains(x.Id))
                .Select(x => x.Id);

            var accountIdsInDb = await AsyncExecuter.ToListAsync(query);
            if (!accountIdsInDb.Any())
            {
                return;
            }

            contact.RemoveAllAccountsExceptGivenIds(accountIdsInDb);

            foreach (var accountId in accountIdsInDb)
            {
                contact.AddAccount(accountId);
            }
        }

    }
}