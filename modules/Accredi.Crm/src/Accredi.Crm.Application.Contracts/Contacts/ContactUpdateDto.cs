using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Accredi.Crm.Contacts
{
    public class ContactUpdateDto : IHasConcurrencyStamp
    {
        [Required]
        public string Reference { get; set; } = null!;
        public string? Title { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        [Required]
        public string LastName { get; set; } = null!;
        public string? NationalIdentifier { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public Guid ContactStateId { get; set; }

        public string ConcurrencyStamp { get; set; } = null!;
    }
}