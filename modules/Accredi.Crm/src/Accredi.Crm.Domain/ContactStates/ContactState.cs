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

namespace Accredi.Crm.ContactStates
{
    public class ContactState : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        public virtual ContactStateType Type { get; set; }

        protected ContactState()
        {

        }

        public ContactState(Guid id, string name, ContactStateType type)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Name = name;
            Type = type;
        }

    }
}