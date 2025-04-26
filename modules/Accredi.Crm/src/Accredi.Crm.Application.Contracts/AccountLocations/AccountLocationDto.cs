using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;

namespace Accredi.Crm.AccountLocations
{
    public class AccountLocationDto : FullAuditedEntityDto<Guid>
    {
        public Guid AccountId { get; set; }
        public string Reference { get; set; } = null!;
        public string Line1 { get; set; } = null!;
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        public string Town { get; set; } = null!;
        public string County { get; set; } = null!;
        public string Postcode { get; set; } = null!;
        public Guid CountryId { get; set; }

    }
}