using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Accredi.Crm.Countries
{
    public class CountryCreateDto
    {
        [Required]
        public string Name { get; set; } = null!;
        [Required]
        public string ISO2Code { get; set; } = null!;
        [Required]
        public string ISO3Code { get; set; } = null!;
    }
}