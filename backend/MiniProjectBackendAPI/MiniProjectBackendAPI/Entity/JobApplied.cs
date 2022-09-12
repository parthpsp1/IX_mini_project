using MiniProjectBackendAPI.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Entity
{
    public class JobApplied
    {
        [Key]
        public int JobsAppliedID { get; set; }

        [ForeignKey("Jobs")]
        public int JobID { get; set; }
        public Job Jobs { get; set; }

        [ForeignKey("Users")]
        public string UserID { get; set; }
        public AuthenticateUser Users{ get; set; }
        public string Status { get; set; }
    }
}
