using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Accredi.Crm.AccountLocations;

using Volo.Abp;

namespace Accredi.Crm.Accounts
{
    public class Account : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? TaxReference { get; set; }

        public ICollection<AccountLocation> AccountLocations { get; private set; }

        protected Account()
        {

        }

        public Account(Guid id, string name)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Name = name;
            AccountLocations = new Collection<AccountLocation>();
        }

    }
}