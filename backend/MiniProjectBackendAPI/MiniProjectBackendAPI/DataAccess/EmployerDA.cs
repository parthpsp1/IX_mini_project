using MiniProjectBackendAPI.Data;
using MiniProjectBackendAPI.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProjectBackendAPI.DataAccess
{
    public interface IEmployerDA
    {
        IEnumerable<Employers> Employer();
        Employers Employers(string id);
        Task<Employers> Employers(Employers employers);
        Employers Employers(Employers employers, string id);
        Employers Remove(string id);
    }

    public class EmployerDA : IEmployerDA
    {
        private readonly ApplicationDbContext _context;

        public EmployerDA(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employers> Employer()
        {
            return _context.Employers.ToList();
        }

        public Employers Employers(string id)
        {
            return _context.Employers.FirstOrDefault(element => element.EmployerId == id);
        }

        public async Task<Employers> Employers(Employers employers)
        {
            var add_employer = await _context.Employers.AddAsync(employers);
            _context.SaveChanges();
            return add_employer.Entity;
        }

        public Employers Employers(Employers employers, string id)
        {
            var update_employer = _context.Employers.Where(element => element.EmployerId == id).ToList();
            foreach (var element in update_employer)
            {
                if (element.EmployerId == id)
                {
                    element.CompanyName = employers.CompanyName;
                    element.Details = employers.Details;
                    element.PhoneNumber = employers.PhoneNumber;
                    element.AlternatePhoneNumber = element.AlternatePhoneNumber;
                    element.Category = employers.Category;

                    var updated_employer = _context.Employers.Update(element);
                    _context.SaveChanges();
                    return updated_employer.Entity;
                }
            }
            return employers;
        }

        public Employers Remove(string id)
        {
            var remove_employer = _context.Employers.Where(element => element.EmployerId == id).FirstOrDefault();
            if (remove_employer.EmployerId == id)
            {
                _context.Employers.Remove(remove_employer);
                _context.SaveChanges();
                return remove_employer;
            }
            return remove_employer;
        }
    }
}
