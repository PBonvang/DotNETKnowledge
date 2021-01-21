using System;

namespace Services.Models
{
    public class CarDetail
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public BrandOverview Brand { get; set; }
    }

    public class CarOverview
    {
        public Guid Id { get; set; }
        public string Model { get; set; }
        public string Brand { get; set; }
    }
}