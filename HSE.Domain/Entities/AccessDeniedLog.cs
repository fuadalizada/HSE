using System;

namespace HSE.Domain.Entities
{
    public class AccessDeniedLog:BaseEntity
    {
        public int? UserId { get; set; }
        public string RemoteIpAddress { get; set; }
        public string BrowserInfo { get; set; }
        public string RefererUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
