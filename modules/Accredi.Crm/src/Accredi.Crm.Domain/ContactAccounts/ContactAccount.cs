using Accredi.Crm.Accounts;
using Accredi.Crm.ContactLevels;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Accredi.Crm.ContactAccounts
{
    public class ContactAccount : FullAuditedEntity<Guid>, IMultiTenant
    {
        public virtual Guid ContactId { get; set; }

        public virtual Guid? TenantId { get; set; }
        public Guid AccountId { get; set; }
        public Guid ContactLevelId { get; set; }

        protected ContactAccount()
        {

        }

        public ContactAccount(Guid id, Guid contactId, Guid accountId, Guid contactLevelId)
        {

            Id = id;
            ContactId = contactId;
            AccountId = accountId;
            ContactLevelId = contactLevelId;
        }

    }
}