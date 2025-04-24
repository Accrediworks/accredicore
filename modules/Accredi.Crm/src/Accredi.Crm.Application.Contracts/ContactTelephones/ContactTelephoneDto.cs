using Accredi.Crm;
using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Accredi.Crm.ContactTelephones
{
    public class ContactTelephoneDto : FullAuditedEntityDto<Guid>
    {
        public Guid ContactId { get; set; }
        public string PhoneNumber { get; set; } = null!;
        public ContactTelephoneType Type { get; set; }

    }
}