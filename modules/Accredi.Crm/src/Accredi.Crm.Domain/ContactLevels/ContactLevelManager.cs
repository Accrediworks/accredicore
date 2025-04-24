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

namespace Accredi.Crm.ContactLevels
{
    public class ContactLevelManager : DomainService
    {
        protected IContactLevelRepository _contactLevelRepository;

        public ContactLevelManager(IContactLevelRepository contactLevelRepository)
        {
            _contactLevelRepository = contactLevelRepository;
        }

        public virtual async Task<ContactLevel> CreateAsync(
        string name, ContactLevelType type)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNull(type, nameof(type));

            var contactLevel = new ContactLevel(
             GuidGenerator.Create(),
             name, type
             );

            return await _contactLevelRepository.InsertAsync(contactLevel);
        }

        public virtual async Task<ContactLevel> UpdateAsync(
            Guid id,
            string name, ContactLevelType type, [CanBeNull] string? concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.NotNull(type, nameof(type));

            var contactLevel = await _contactLevelRepository.GetAsync(id);

            contactLevel.Name = name;
            contactLevel.Type = type;

            contactLevel.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _contactLevelRepository.UpdateAsync(contactLevel);
        }

    }
}