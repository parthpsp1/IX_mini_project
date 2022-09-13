using MiniProjectBackendAPI.Data;
using MiniProjectBackendAPI.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MiniProjectBackendAPI.DataAccess
{
    public interface IEmployerDA
    {
        IEnumerable<Employer> Employers();
        Employer Employer(string id);
        int Employer(Employer employer);
        bool UpdateEmployer(Employer employer);
        bool Remove(string id);
    }

    public class EmployerDA : IEmployerDA
    {
        private readonly JobPortalDbContext _context;

        public EmployerDA(JobPortalDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Employer> Employers()
        {
            return _context.Employers.ToList();
        }

        public Employer Employer(string id)
        {
            return _context.Employers.FirstOrDefault(element => element.EmployerId == id);
        }

        public int Employer(Employer employer)
        {
            _context.Employers.Add(employer);
            _context.SaveChanges();
            return employer.Id;
        }

        public bool UpdateEmployer(Employer employer)
        {
            var existingEmployer = _context.Employers.FirstOrDefault(element => element.EmployerId == employer.EmployerId);
            if (existingEmployer != null)
            {
                existingEmployer.CompanyName = employer.CompanyName;
                existingEmployer.Details = employer.Details;
                existingEmployer.PhoneNumber = employer.PhoneNumber;
                existingEmployer.AlternatePhoneNumber = employer.AlternatePhoneNumber;
                existingEmployer.Category = employer.Category;
                _context.SaveChanges();
                return true;
            }
            else
            {
            return false;
            }
        }

        public bool Remove(string id)
        {
            var removeEmployer = _context.Employers.FirstOrDefault(element => element.EmployerId == id);
            if (removeEmployer != null)
            {
                _context.Employers.Remove(removeEmployer);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
