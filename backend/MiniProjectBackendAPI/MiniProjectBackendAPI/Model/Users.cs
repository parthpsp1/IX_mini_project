namespace MiniProjectBackendAPI.Model
{
    public class Users
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public decimal? TenthPercentage { get; set; }
        public decimal? TwelthPercentage { get; set; }
        public decimal? DiplomaPercentage { get; set; }
        public decimal? BachlorsPercentage { get; set; }
        public decimal? MastersPercentage { get; set; }
        public decimal? DoctoratePhDPercentage { get; set; }
        public string Certification { get; set; }
    }
}
