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

namespace Accredi.Crm.ContactEmails
{
    public class ContactEmail : FullAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid ContactId { get; set; }

        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Email { get; set; }

        public virtual ContactEmailType Type { get; set; }

        protected ContactEmail()
        {

        }

        public ContactEmail(Guid id, Guid contactId, string email, ContactEmailType type)
        {

            Id = id;
            Check.NotNull(email, nameof(email));
            ContactId = contactId;
            Email = email;
            Type = type;
        }

    }
}