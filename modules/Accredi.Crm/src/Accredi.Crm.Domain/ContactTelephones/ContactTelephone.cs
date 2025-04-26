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

namespace Accredi.Crm.ContactTelephones
{
    public class ContactTelephone : FullAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid ContactId { get; set; }

        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Telephone { get; set; }

        public virtual ContactTelephoneType Type { get; set; }

        protected ContactTelephone()
        {

        }

        public ContactTelephone(Guid id, Guid contactId, string telephone, ContactTelephoneType type)
        {

            Id = id;
            Check.NotNull(telephone, nameof(telephone));
            ContactId = contactId;
            Telephone = telephone;
            Type = type;
        }

    }
}