using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Framework
    {
        public Guid Id { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<User>? Users { get; set; }
        public List<Feature>? Features { get; set; }
    }
}