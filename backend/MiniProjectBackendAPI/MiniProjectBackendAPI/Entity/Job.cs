using MiniProjectBackendAPI.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Entity
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }

        [ForeignKey("Employers")]
        public string EmployerId { get; set; }
        public AuthenticateUser AuthenticateUser { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PersonOfContact { get; set; }
        public string PayRange { get; set; }
        public List<JobApplied> JobsApplied { get; set; }
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
