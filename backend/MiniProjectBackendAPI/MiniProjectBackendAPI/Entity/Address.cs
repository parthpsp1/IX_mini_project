using System.ComponentModel.DataAnnotations.Schema;

namespace MiniProjectBackendAPI.Entity
{
    public class Address
    {
        public int AddressID { get; set; }
        
        [ForeignKey("Employers")]
        public int EmployerID { get; set; }
        public Employer Employers { get; set; }
        public string StreetName { get; set; }
        public string Landmark { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string State { get; set; }
        public string Pincode { get; set; }
    }
}
