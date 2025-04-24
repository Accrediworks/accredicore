using Accredi.Crm;
using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Accredi.Crm.ContactStates
{
    public class ContactStateDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; } = null!;
        public ContactStateType Type { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

    }
}