using System;

namespace HSE.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Fincode { get; set; }
        public string Structure { get; set; }
        public string Position { get; set; }
        public bool Active { get; set; }
        public bool Gender { get; set; }
        public string LayoutOptionsJson { get; set; }
        public DateTime? TourDate { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
