using Accredi.Crm;
using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Accredi.Crm.ContactEmails
{
    public class ContactEmailDto : FullAuditedEntityDto<Guid>
    {
        public Guid ContactId { get; set; }
        public string Email { get; set; } = null!;
        public ContactEmailType Type { get; set; }

    }
}