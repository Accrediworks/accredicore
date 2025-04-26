using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.ContactEmails
{
    public class GetContactEmailListInput : PagedAndSortedResultRequestDto
    {
        public Guid ContactId { get; set; }
    }
}