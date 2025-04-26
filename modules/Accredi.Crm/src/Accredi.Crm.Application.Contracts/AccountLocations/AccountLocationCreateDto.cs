using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Accredi.Crm.AccountLocations
{
    public class AccountLocationCreateDto
    {
        public Guid AccountId { get; set; }
        [Required]
        public string Reference { get; set; } = null!;
        [Required]
        public string Line1 { get; set; } = null!;
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }
        [Required]
        public string Town { get; set; } = null!;
        [Required]
        public string County { get; set; } = null!;
        [Required]
        public string Postcode { get; set; } = null!;
        public Guid CountryId { get; set; }
    }
}