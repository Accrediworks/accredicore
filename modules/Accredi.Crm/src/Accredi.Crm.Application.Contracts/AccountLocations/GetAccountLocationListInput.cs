using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.AccountLocations
{
    public class GetAccountLocationListInput : PagedAndSortedResultRequestDto
    {
        public Guid AccountId { get; set; }
    }
}