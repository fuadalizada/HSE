using System;

namespace HSE.Domain.Entities
{
    public class Authenticate
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string FatherName { get; set; }
        public string RoleName { get; set; }
        public string Fincode { get; set; }
        public string PhoneNumber { get; set; }
        public string Position { get; set; }
        public string UserOrgId { get; set; }
        public bool IsManager { get; set; }
        public string LayoutOptions { get; set; }
        public DateTime? TourDate { get; set; }
    }
}
