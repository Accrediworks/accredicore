using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Accredi.Crm.Contacts
{
    public abstract class Contact : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [CanBeNull]
        public virtual string? Title { get; set; }

        [NotNull]
        public virtual string FirstName { get; set; }

        [CanBeNull]
        public virtual string? MiddleName { get; set; }

        [NotNull]
        public virtual string LastName { get; set; }

        [CanBeNull]
        public virtual string? NationalIdentifier { get; set; }

        public virtual DateOnly? DateOfBirth { get; set; }

        public ICollection<ContactAccount> Accounts { get; private set; }

        protected Contact()
        {

        }

        public Contact(Guid id, string firstName, string lastName, string? title = null, string? middleName = null, string? nationalIdentifier = null, DateOnly? dateOfBirth = null)
        {

            Id = id;
            Check.NotNull(firstName, nameof(firstName));
            Check.NotNull(lastName, nameof(lastName));
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            MiddleName = middleName;
            NationalIdentifier = nationalIdentifier;
            DateOfBirth = dateOfBirth;
            Accounts = new Collection<ContactAccount>();
        }
        public virtual void AddAccount(Guid accountId)
        {
            Check.NotNull(accountId, nameof(accountId));

            if (IsInAccounts(accountId))
            {
                return;
            }

            Accounts.Add(new ContactAccount(Id, accountId));
        }

        public virtual void RemoveAccount(Guid accountId)
        {
            Check.NotNull(accountId, nameof(accountId));

            if (!IsInAccounts(accountId))
            {
                return;
            }

            Accounts.RemoveAll(x => x.AccountId == accountId);
        }

        public virtual void RemoveAllAccountsExceptGivenIds(List<Guid> accountIds)
        {
            Check.NotNullOrEmpty(accountIds, nameof(accountIds));

            Accounts.RemoveAll(x => !accountIds.Contains(x.AccountId));
        }

        public virtual void RemoveAllAccounts()
        {
            Accounts.RemoveAll(x => x.ContactId == Id);
        }

        private bool IsInAccounts(Guid accountId)
        {
            return Accounts.Any(x => x.AccountId == accountId);
        }
    }
}