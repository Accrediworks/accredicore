using Accredi.Crm;
using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.ContactLevels
{
    public class GetContactLevelsInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public ContactLevelType? Type { get; set; }

        public GetContactLevelsInput()
        {

        }
    }
}