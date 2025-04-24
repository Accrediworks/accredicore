using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.ContactTelephones
{
    public class GetContactTelephoneListInput : PagedAndSortedResultRequestDto
    {
        public Guid ContactId { get; set; }
    }
}