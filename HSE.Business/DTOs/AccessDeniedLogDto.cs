using System;

namespace HSE.Business.DTOs
{
    public class AccessDeniedLogDto:BaseDto
    {
        public int? UserId { get; set; }
        public string RemoteIpAddress { get; set; }
        public string BrowserInfo { get; set; }
        public string RefererUrl { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
