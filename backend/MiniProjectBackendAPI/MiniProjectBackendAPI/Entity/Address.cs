using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Entity
{
    public class Address
    {
        public int AddressID { get; set; }
        
        [ForeignKey("Employers")]
        public int EmployerId { get; set; }
        public Employer Employers { get; set; }
        public string StreetName { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }

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
