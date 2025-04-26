using Accredi.Crm.ContactStates;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Accredi.Crm.ContactTelephones;
using Accredi.Crm.ContactEmails;
using Accredi.Crm.ContactAccounts;

using Volo.Abp;

namespace Accredi.Crm.Contacts
{
    public class Contact : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Reference { get; set; }

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
        public Guid ContactStateId { get; set; }
        public ICollection<ContactTelephone> ContactTelephones { get; private set; }
        public ICollection<ContactEmail> ContactEmails { get; private set; }
        public ICollection<ContactAccount> ContactAccounts { get; private set; }

        protected Contact()
        {

        }

        public Contact(Guid id, Guid contactStateId, string reference, string firstName, string lastName, string? title = null, string? middleName = null, string? nationalIdentifier = null, DateOnly? dateOfBirth = null)
        {

            Id = id;
            Check.NotNull(reference, nameof(reference));
            Check.NotNull(firstName, nameof(firstName));
            Check.NotNull(lastName, nameof(lastName));
            Reference = reference;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            MiddleName = middleName;
            NationalIdentifier = nationalIdentifier;
            DateOfBirth = dateOfBirth;
            ContactStateId = contactStateId;
            ContactTelephones = new Collection<ContactTelephone>();
            ContactEmails = new Collection<ContactEmail>();
            ContactAccounts = new Collection<ContactAccount>();
        }

    }
}