using System;

namespace Services
{
    public class BaseRequest
    {
        public string UserId { get; set; }
        public DateTime RequestedAt { get; set; }
    }
}