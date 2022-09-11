using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Entity
{
    public class Users
    {
        [Key]
        public int UserID { get; set; }
        [Required]
        //[MaxLength(50), MinLength(2)]
        public string FirstName { get; set; }

        [Required]
        //[MaxLength(50), MinLength(2)]
        public string LastName { get; set; }

        [Required]
        //[MaxLength(10), MinLength(10)]
        public string PhoneNumber { get; set; }

        public string AlternatePhoneNumber { get; set; }

        //[MaxLength(50), MinLength(2)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? TenthPercentage { get; set; }

        //[MaxLength(50), MinLength(2)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? TwelthPercentage { get; set; }

        //[MaxLength(50), MinLength(2)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? DiplomaPercentage { get; set; }

        //[MaxLength(50), MinLength(2)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? BachlorsPercentage { get; set; }

        //[MaxLength(50), MinLength(2)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? MastersPercentage { get; set; }

        //[MaxLength(50), MinLength(2)]
        [Column(TypeName = "decimal(5,2)")]
        public decimal? DoctoratePhDPercentage { get; set; }
        public bool WorkStatus { get; set; }
        public string Certification { get; set; }

        //public bool Resume { get; set; }
    }
}
