using Accredi.Crm;
using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.ContactTelephones
{
    public class GetContactTelephonesInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Telephone { get; set; }
        public ContactTelephoneType? Type { get; set; }

        public GetContactTelephonesInput()
        {

        }
    }
}