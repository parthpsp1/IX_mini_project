using MiniProjectBackendAPI.Authentication;
using MiniProjectBackendAPI.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Model
{
    public class JobsApplied
    {
        public int JobsAppliedId { get; set; }

        [ForeignKey("Jobs")]
        public int JobId { get; set; }
        public Job Jobs { get; set; }

        [ForeignKey("Users")]
        public string UserId { get; set; }
        public AuthenticateUser Users { get; set; }
        public string Status { get; set; }
    }
}
