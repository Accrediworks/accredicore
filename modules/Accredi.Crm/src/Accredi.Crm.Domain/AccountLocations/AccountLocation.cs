using Accredi.Crm.Countries;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Accredi.Crm.AccountLocations
{
    public class AccountLocation : FullAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid AccountId { get; set; }

        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Reference { get; set; }

        [NotNull]
        public virtual string Line1 { get; set; }

        [CanBeNull]
        public virtual string? Line2 { get; set; }

        [CanBeNull]
        public virtual string? Line3 { get; set; }

        [NotNull]
        public virtual string Town { get; set; }

        [NotNull]
        public virtual string County { get; set; }

        [NotNull]
        public virtual string Postcode { get; set; }
        public Guid CountryId { get; set; }

        protected AccountLocation()
        {

        }

        public AccountLocation(Guid id, Guid accountId, Guid countryId, string reference, string line1, string town, string county, string postcode, string? line2 = null, string? line3 = null)
        {

            Id = id;
            Check.NotNull(reference, nameof(reference));
            Check.NotNull(line1, nameof(line1));
            Check.NotNull(town, nameof(town));
            Check.NotNull(county, nameof(county));
            Check.NotNull(postcode, nameof(postcode));
            AccountId = accountId;
            Reference = reference;
            Line1 = line1;
            Town = town;
            County = county;
            Postcode = postcode;
            Line2 = line2;
            Line3 = line3;
            CountryId = countryId;
        }

    }
}