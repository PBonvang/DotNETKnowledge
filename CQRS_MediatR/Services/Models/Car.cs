using System;

namespace Services.Models
{
    public class Car
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public BrandOverview Brand { get; set; }
    }
}