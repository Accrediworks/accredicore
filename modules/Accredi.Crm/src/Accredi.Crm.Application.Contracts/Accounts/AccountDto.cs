using System;
using System.Collections.Generic;
using Accredi.Crm.AccountLocations;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Accredi.Crm.Accounts
{
    public class AccountDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Name { get; set; } = null!;
        public string? TaxReference { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

        public List<AccountLocationWithNavigationPropertiesDto> AccountLocations { get; set; } = new();
    }
}