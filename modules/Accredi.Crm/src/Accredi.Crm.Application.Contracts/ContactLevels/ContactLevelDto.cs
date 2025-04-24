using Accredi.Crm;
using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Accredi.Crm.ContactLevels
{
    public class ContactLevelDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; } = null!;
        public ContactLevelType Type { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}