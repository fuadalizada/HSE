using System;

namespace HSE.Domain.Entities
{
    public class LoginLog : BaseEntity
    {
        public string Email { get; set; }

        public string RemoteIpAddress { get; set; }

        public string BrowserInfo { get; set; }

        public bool Success { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
