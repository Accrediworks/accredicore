using Accredi.Crm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Accredi.Crm.ContactStates
{
    public class ContactStateManager : DomainService
    {
        protected IContactStateRepository _contactStateRepository;

        public ContactStateManager(IContactStateRepository contactStateRepository)
        {
            _contactStateRepository = contactStateRepository;
        }

        public virtual async Task<ContactState> CreateAsync(
        string name, ContactStateType type)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNull(type, nameof(type));

            var contactState = new ContactState(
             GuidGenerator.Create(),
             name, type
             );

            return await _contactStateRepository.InsertAsync(contactState);
        }

        public virtual async Task<ContactState> UpdateAsync(
            Guid id,
            string name, ContactStateType type, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNull(type, nameof(type));

            var contactState = await _contactStateRepository.GetAsync(id);

            contactState.Name = name;
            contactState.Type = type;

            contactState.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _contactStateRepository.UpdateAsync(contactState);
        }

    }
}