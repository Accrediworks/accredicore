using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.Accounts
{
    public class GetAccountsInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Name { get; set; }

        public GetAccountsInput()
        {

        }
    }
}