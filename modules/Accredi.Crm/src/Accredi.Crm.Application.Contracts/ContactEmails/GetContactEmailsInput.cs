using Accredi.Crm;
using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.ContactEmails
{
    public class GetContactEmailsInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Email { get; set; }
        public ContactEmailType? Type { get; set; }

        public GetContactEmailsInput()
        {

        }
    }
}