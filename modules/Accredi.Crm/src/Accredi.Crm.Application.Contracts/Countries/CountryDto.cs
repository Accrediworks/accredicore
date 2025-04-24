using System;
using System.Collections.Generic;

using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Accredi.Crm.Countries
{
    public class CountryDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; } = null!;
        public string ISO2Code { get; set; } = null!;
        public string ISO3Code { get; set; } = null!;

        public string ConcurrencyStamp { get; set; } = null!;

    }
}