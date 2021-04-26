using System;

namespace HSE.Business.DTOs
{
    public class LoginLogDto:BaseDto
    {
        public string Email { get; set; }

        public string RemoteIpAddress { get; set; }

        public string BrowserInfo { get; set; }

        public bool Success { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
