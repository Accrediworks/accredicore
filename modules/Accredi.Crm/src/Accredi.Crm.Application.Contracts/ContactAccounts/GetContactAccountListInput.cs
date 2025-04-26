using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.ContactAccounts
{
    public class GetContactAccountListInput : PagedAndSortedResultRequestDto
    {
        public Guid ContactId { get; set; }
    }
}