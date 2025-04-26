using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Accredi.Crm.Countries
{
    public class Country : FullAuditedAggregateRoot<Guid>
    {
        [NotNull]
        public virtual string Name { get; set; }

        [NotNull]
        public virtual string ISO2Code { get; set; }

        [NotNull]
        public virtual string ISO3Code { get; set; }

        protected Country()
        {

        }

        public Country(Guid id, string name, string iSO2Code, string iSO3Code)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.NotNull(iSO2Code, nameof(iSO2Code));
            Check.NotNull(iSO3Code, nameof(iSO3Code));
            Name = name;
            ISO2Code = iSO2Code;
            ISO3Code = iSO3Code;
        }

    }
}