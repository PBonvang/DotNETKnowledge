using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public List<Framework>? Frameworks { get; set; }
    }
}