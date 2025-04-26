using Accredi.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Accredi.Crm.ContactEmails
{
    public class ContactEmailManager : DomainService
    {
        protected IContactEmailRepository _contactEmailRepository;

        public ContactEmailManager(IContactEmailRepository contactEmailRepository)
        {
            _contactEmailRepository = contactEmailRepository;
        }

        public virtual async Task<ContactEmail> CreateAsync(
        Guid contactId, string email, ContactEmailType type)
        {
            Check.NotNullOrWhiteSpace(email, nameof(email));
            Check.NotNull(type, nameof(type));

            var contactEmail = new ContactEmail(
             GuidGenerator.Create(),
             contactId, email, type
             );

            return await _contactEmailRepository.InsertAsync(contactEmail);
        }

        public virtual async Task<ContactEmail> UpdateAsync(
            Guid id,
            Guid contactId, string email, ContactEmailType type
        )
        {
            Check.NotNullOrWhiteSpace(email, nameof(email));
            Check.NotNull(type, nameof(type));

            var contactEmail = await _contactEmailRepository.GetAsync(id);

            contactEmail.ContactId = contactId;
            contactEmail.Email = email;
            contactEmail.Type = type;

            return await _contactEmailRepository.UpdateAsync(contactEmail);
        }

    }
}