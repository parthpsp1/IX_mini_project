using MiniProjectBackendAPI.Authentication;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Entity
{
    public class JobApplied
    {
        [Key]
        public int JobsAppliedId { get; set; }

        [ForeignKey("Jobs")]
        public int JobId { get; set; }
        public Job Jobs { get; set; }

        [ForeignKey("Users")]
        public string UserId { get; set; }
        public AuthenticateUser Users{ get; set; }
        public string Status { get; set; }

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