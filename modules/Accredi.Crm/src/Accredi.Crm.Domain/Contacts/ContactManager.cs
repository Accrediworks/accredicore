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

        public ContactManager(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public virtual async Task<Contact> CreateAsync(
        Guid contactStateId, string reference, string firstName, string lastName, string? title = null, string? middleName = null, string? nationalIdentifier = null, DateOnly? dateOfBirth = null)
        {
            Check.NotNull(contactStateId, nameof(contactStateId));
            Check.NotNullOrWhiteSpace(reference, nameof(reference));
            Check.NotNullOrWhiteSpace(firstName, nameof(firstName));
            Check.NotNullOrWhiteSpace(lastName, nameof(lastName));

            var contact = new Contact(
             GuidGenerator.Create(),
             contactStateId, reference, firstName, lastName, title, middleName, nationalIdentifier, dateOfBirth
             );

            return await _contactRepository.InsertAsync(contact);
        }

        public virtual async Task<Contact> UpdateAsync(
            Guid id,
            Guid contactStateId, string reference, string firstName, string lastName, string? title = null, string? middleName = null, string? nationalIdentifier = null, DateOnly? dateOfBirth = null, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNull(contactStateId, nameof(contactStateId));
            Check.NotNullOrWhiteSpace(reference, nameof(reference));
            Check.NotNullOrWhiteSpace(firstName, nameof(firstName));
            Check.NotNullOrWhiteSpace(lastName, nameof(lastName));

            var contact = await _contactRepository.GetAsync(id);

            contact.ContactStateId = contactStateId;
            contact.Reference = reference;
            contact.FirstName = firstName;
            contact.LastName = lastName;
            contact.Title = title;
            contact.MiddleName = middleName;
            contact.NationalIdentifier = nationalIdentifier;
            contact.DateOfBirth = dateOfBirth;

            contact.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _contactRepository.UpdateAsync(contact);
        }

    }
}