using MiniProjectBackendAPI.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Model
{
    public class JobsModel
    {
        public int JobID { get; set; }

        [ForeignKey("Employers")]
        public int EmployerID { get; set; }
        public Employers Employers { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PersonOfContact { get; set; }
        public string PayRange { get; set; }
    }
}
