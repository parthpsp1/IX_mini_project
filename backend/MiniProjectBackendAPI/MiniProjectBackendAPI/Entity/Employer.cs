using MiniProjectBackendAPI.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Entity
{
    public class Employer
    {
        public int Id { get; set; }

        [ForeignKey("AuthenticateUser")]
        public string EmployerId { get; set; }
        public AuthenticateUser AuthenticateUser{ get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string Details { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public string AlternatePhoneNumber { get; set; }

        [Required]
        public string Category { get; set; }
    }
}
