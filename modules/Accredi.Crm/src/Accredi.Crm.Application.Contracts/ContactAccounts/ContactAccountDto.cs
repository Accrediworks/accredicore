using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Accredi.Crm.ContactAccounts
{
    public class ContactAccountDto : FullAuditedEntityDto<Guid>
    {
        public Guid ContactId { get; set; }
        public Guid AccountId { get; set; }
        public Guid ContactLevelId { get; set; }

    }
}