using System;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Feature
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}