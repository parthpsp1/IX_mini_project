using MiniProjectBackendAPI.Entity;
using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Model
{
    public class Jobs
    {
        public int JobId { get; set; }
        public string EmployerId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string PersonOfContact { get; set; }
        public string PayRange { get; set; }
    }
}
