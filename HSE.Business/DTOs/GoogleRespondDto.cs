using System;

namespace HSE.Business.DTOs
{
    public class GoogleRespondDto
    {
        public bool Success { get; set; }
        public double Score { get; set; }
        public string Action { get; set; }
        public DateTime ChallangeDt { get; set; }
        public string HostName { get; set; }
    }
}
