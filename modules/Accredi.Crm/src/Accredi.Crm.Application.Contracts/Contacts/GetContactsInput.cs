using Volo.Abp.Application.Dtos;
using System;

namespace Accredi.Crm.Contacts
{
    public class GetContactsInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Reference { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? NationalIdentifier { get; set; }
        public DateOnly? DateOfBirthMin { get; set; }
        public DateOnly? DateOfBirthMax { get; set; }
        public Guid? ContactStateId { get; set; }
        public Guid? ContactLevelId { get; set; }
        public Guid? AccountId { get; set; }

        public GetContactsInput()
        {

        }
    }
}