using System;

namespace HSE.Domain.Entities
{
    public class GoogleRespond
    {
        public bool Success { get; set; }
        public double Score { get; set; }
        public string Action { get; set; }
        public DateTime ChallangeDt { get; set; }
        public string HostName { get; set; }
    }
}
