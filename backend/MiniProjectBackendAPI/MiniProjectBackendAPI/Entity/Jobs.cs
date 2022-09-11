using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Entity
{
    public class Jobs
    {
        [Key]
        public int JobID { get; set; }

        [ForeignKey("Employers")]
        public int EmployerID { get; set; }
        public Employers Employers { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PersonOfContact { get; set; }
        public string PayRange { get; set; }
        public List<JobsApplied> JobsApplied { get; set; }

    }
}
