using MiniProjectBackendAPI.Authentication;
using MiniProjectBackendAPI.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Model
{
    public class JobsAppliedModel
    {
        public int JobsAppliedID { get; set; }

        [ForeignKey("Jobs")]
        public int JobID { get; set; }
        public Jobs Jobs { get; set; }

        [ForeignKey("Users")]
        public string UserID { get; set; }
        public AuthenticateUser Users { get; set; }
        public string Status { get; set; }
    }
}
