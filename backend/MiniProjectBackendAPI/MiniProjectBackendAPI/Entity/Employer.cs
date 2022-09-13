using MiniProjectBackendAPI.Authentication;
using System;
using System.ComponentModel;
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

        [Required]
        public int CreatedBy { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; }

        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }

        [Required, DefaultValue(true)]
        public bool IsActive { get; set; }
    }
}
