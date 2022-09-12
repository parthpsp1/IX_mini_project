using System.ComponentModel.DataAnnotations;

namespace MiniProjectBackendAPI.Model
{
    public class EmployerRegistration
    {
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string Email { get; set; }
        public string CompanyName { get; set; }
        public string Details { get; set; }
        public string PhoneNumber { get; set; }
        public string AlternatePhoneNumber { get; set; }
        public string Category { get; set; }
    }
}
