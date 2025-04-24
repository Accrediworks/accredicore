using System;
using System.Collections.Generic;
using Accredi.Crm.ContactEmails;
using Accredi.Crm.ContactTelephones;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace Accredi.Crm.Contacts
{
    public class ContactDto : FullAuditedEntityDto<Guid>, IHasConcurrencyStamp
    {
        public string Reference { get; set; } = null!;
        public string? Title { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? NationalIdentifier { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public Guid ContactStateId { get; set; }
        public Guid ContactLevelId { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;

        public List<ContactEmailDto> ContactEmails { get; set; } = new();
        public List<ContactTelephoneDto> ContactTelephones { get; set; } = new();
    }
}