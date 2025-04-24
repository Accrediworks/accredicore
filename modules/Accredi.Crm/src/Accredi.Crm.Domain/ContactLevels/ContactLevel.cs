using Accredi.Crm;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Accredi.Crm.ContactLevels
{
    public class ContactLevel : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        public virtual ContactLevelType Type { get; set; }

        protected ContactLevel()
        {

        }

        public ContactLevel(Guid id, string name, ContactLevelType type)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Name = name;
            Type = type;
        }

    }
}