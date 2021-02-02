using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class FrameworkUserLink
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid FrameworkId { get; set; }
        public Framework Framework { get; set; }
    }
}