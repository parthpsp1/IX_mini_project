using Microsoft.AspNetCore.Identity;
using MiniProjectBackendAPI.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Authentication
{
    public class AuthenticateUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string AlternatePhoneNumber { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? TenthPercentage { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? TwelthPercentage { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? DiplomaPercentage { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? BachlorsPercentage { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? MastersPercentage { get; set; }

        [Column(TypeName = "decimal(5,2)")]
        public decimal? DoctoratePhDPercentage { get; set; }
        public string Certification { get; set; }
        public List<JobApplied> JobsApplied { get; set; }
    }
}
