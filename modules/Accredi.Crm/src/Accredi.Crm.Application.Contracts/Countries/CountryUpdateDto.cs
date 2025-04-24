using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace Accredi.Crm.Countries
{
    public class CountryUpdateDto : IHasConcurrencyStamp
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string ISO2Code { get; set; } = null!;
        [Required]
        public string ISO3Code { get; set; } = null!;

        public string ConcurrencyStamp { get; set; } = null!;
    }
}