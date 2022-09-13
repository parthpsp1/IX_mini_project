using MiniProjectBackendAPI.DataAccess;
using System.Collections.Generic;
using MiniProjectBackendAPI.Model;

namespace MiniProjectBackendAPI.Service
{
    public interface IEmployerService
    {
        IEnumerable<Employer> Employers();
        Employer Employer(string id);
        int Employer(Employer employer);
        bool UpdateEmployer(Employer employer);
        bool Remove(string id);
    }

    public class EmployerService : IEmployerService
    {
        private readonly IEmployerDA _employerDA;

        public EmployerService(IEmployerDA employerDA)
        {
            _employerDA = employerDA;
        }
        public IEnumerable<Employer> Employers()
        {
            var GetAllEmployers = _employerDA.Employers();
            List<Employer> employerList = new();
            foreach(var element in GetAllEmployers)
            {
                employerList.Add(new Employer
                {
                    EmployerId = element.EmployerId,
                    CompanyName = element.CompanyName,
                    Details = element.Details,
                    PhoneNumber = element.PhoneNumber,
                    AlternatePhoneNumber = element.AlternatePhoneNumber,
                    Category = element.Category
                });
            }
            return employerList;
        }
        public Employer Employer(string id)
        {
            var existingEmployer = _employerDA.Employer(id);
            if (existingEmployer == null)
                return null;
            else
            {
                return new Employer
                {
                    EmployerId = existingEmployer.EmployerId,
                    CompanyName = existingEmployer.CompanyName,
                    Details = existingEmployer.Details,
                    PhoneNumber = existingEmployer.PhoneNumber,
                    AlternatePhoneNumber = existingEmployer.AlternatePhoneNumber,
                    Category = existingEmployer.Category,
                };
            }
        }

        public int Employer(Employer employer)
        {
            var newEmployer = new Entity.Employer
            {
                EmployerId = employer.EmployerId,
                CompanyName = employer.CompanyName,
                Details = employer.Details,
                PhoneNumber = employer.PhoneNumber,
                AlternatePhoneNumber = employer.AlternatePhoneNumber,
                Category = employer.Category
            };

            _employerDA.Employer(newEmployer);
            return 0;
        }

        public bool UpdateEmployer(Employer employer)
        {
            var updatedEmployer = new Entity.Employer
            {
                EmployerId = employer.EmployerId,
                CompanyName = employer.CompanyName,
                Details = employer.Details,
                PhoneNumber = employer.PhoneNumber,
                AlternatePhoneNumber = employer.AlternatePhoneNumber,
                Category = employer.Category,
            };
            _employerDA.UpdateEmployer(updatedEmployer);
            return true;
        }
        public bool Remove(string id)
        {
            var remove_employer = _employerDA.Remove(id);
            if (remove_employer)
                return true;
            return false;
        }
    }
}
