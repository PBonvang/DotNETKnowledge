using System;
using System.Collections.Generic;

namespace Services.Models
{
    public class BrandDetail
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<CarOverview> Cars { get; set; }
    }

    public class BrandOverview
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}