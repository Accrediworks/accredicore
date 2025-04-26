using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.ContactAccounts
{
    public class GetContactAccountsInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public Guid? AccountId { get; set; }
        public Guid? ContactLevelId { get; set; }

        public GetContactAccountsInput()
        {

        }
    }
}