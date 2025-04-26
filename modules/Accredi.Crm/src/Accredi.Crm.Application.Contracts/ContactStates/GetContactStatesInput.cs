using Accredi.Crm;
using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.ContactStates
{
    public class GetContactStatesInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Name { get; set; }
        public ContactStateType? Type { get; set; }

        public GetContactStatesInput()
        {

        }
    }
}