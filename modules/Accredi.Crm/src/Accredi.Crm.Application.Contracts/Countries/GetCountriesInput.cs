using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.Countries
{
    public class GetCountriesInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public string? ISO2Code { get; set; }
        public string? ISO3Code { get; set; }

        public GetCountriesInput()
        {

        }
    }
}