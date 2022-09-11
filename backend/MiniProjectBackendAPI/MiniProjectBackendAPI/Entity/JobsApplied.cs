using MiniProjectBackendAPI.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Entity
{
    public class JobsApplied
    {
        [Key]
        public int JobsAppliedID { get; set; }

        [ForeignKey("Jobs")]
        public int JobID { get; set; }
        public Jobs Jobs { get; set; }

        [ForeignKey("Users")]
        public string UserID { get; set; }
        public AuthenticateUser Users{ get; set; }
        public string Status { get; set; }
    }
}
