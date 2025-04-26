using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.AccountLocations
{
    public class GetAccountLocationsInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Reference { get; set; }
        public Guid? CountryId { get; set; }

        public GetAccountLocationsInput()
        {

        }
    }
}