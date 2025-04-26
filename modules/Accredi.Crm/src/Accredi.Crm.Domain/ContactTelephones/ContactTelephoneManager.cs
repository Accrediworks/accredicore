using Accredi.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Accredi.Crm.ContactTelephones
{
    public class ContactTelephoneManager : DomainService
    {
        protected IContactTelephoneRepository _contactTelephoneRepository;

        public ContactTelephoneManager(IContactTelephoneRepository contactTelephoneRepository)
        {
            _contactTelephoneRepository = contactTelephoneRepository;
        }

        public virtual async Task<ContactTelephone> CreateAsync(
        Guid contactId, string telephone, ContactTelephoneType type)
        {
            Check.NotNullOrWhiteSpace(telephone, nameof(telephone));
            Check.NotNull(type, nameof(type));

            var contactTelephone = new ContactTelephone(
             GuidGenerator.Create(),
             contactId, telephone, type
             );

            return await _contactTelephoneRepository.InsertAsync(contactTelephone);
        }

        public virtual async Task<ContactTelephone> UpdateAsync(
            Guid id,
            Guid contactId, string telephone, ContactTelephoneType type
        )
        {
            Check.NotNullOrWhiteSpace(telephone, nameof(telephone));
            Check.NotNull(type, nameof(type));

            var contactTelephone = await _contactTelephoneRepository.GetAsync(id);

            contactTelephone.ContactId = contactId;
            contactTelephone.Telephone = telephone;
            contactTelephone.Type = type;

            return await _contactTelephoneRepository.UpdateAsync(contactTelephone);
        }

    }
}