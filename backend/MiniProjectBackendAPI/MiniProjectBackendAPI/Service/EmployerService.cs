using MiniProjectBackendAPI.DataAccess;
using MiniProjectBackendAPI.Entity;
using MiniProjectBackendAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using MiniProjectBackendAPI.Data;

namespace MiniProjectBackendAPI.Service
{
    public interface IEmployerService
    {
        IEnumerable<EmployerModel> Employers();
        EmployerModel Employer(string id);
        Task<EmployerModel> Employer(EmployerModel employerModel);

        EmployerModel Employer(EmployerModel employerModel, string id);
        EmployerModel Remove(string id);
    }

    public class EmployerService : IEmployerService
    {
        private readonly IEmployerDA _employerDA;
        private readonly ApplicationDbContext _context;

        public EmployerService(IEmployerDA employerDA, ApplicationDbContext context)
        {
            _employerDA = employerDA;
            _context = context;
        }
        public IEnumerable<EmployerModel> Employers()
        {
            var get_all_employers = _employerDA.Employer();
            List<EmployerModel> employer_list = new();
            foreach(var element in get_all_employers)
            {
                employer_list.Add(new EmployerModel
                {
                    EmployerId = element.EmployerId,
                    //Username = _context.Employers.Select(obj => obj.CompanyName),
                    //Email
                    CompanyName = element.CompanyName,
                    Details = element.Details,
                    PhoneNumber = element.PhoneNumber,
                    AlternatePhoneNumber = element.AlternatePhoneNumber,
                    Category = element.Category
                });
            }
            return employer_list;
        }
        public EmployerModel Employer(string id)
        {
            var get_employer_by_id = _employerDA.Employers(id);
            if (get_employer_by_id == null)
                return null;
            else
            {
                return new EmployerModel
                {
                    EmployerId = get_employer_by_id.EmployerId,
                };
            }
        }

        public async Task<EmployerModel> Employer(EmployerModel employerModel)
        {
            var new_employer = new Employers
            {
                EmployerId = employerModel.EmployerId,
                CompanyName = employerModel.CompanyName,
                Details = employerModel.Details,
                PhoneNumber = employerModel.PhoneNumber,
                AlternatePhoneNumber = employerModel.AlternatePhoneNumber,
                Category = employerModel.Category
            };

            var add_new_employer = await _employerDA.Employers(new_employer);
            return new EmployerModel
            {
                EmployerId = add_new_employer.EmployerId
            };
        }


        public EmployerModel Remove(string id)
        {
            var remove_employer = _employerDA.Remove(id);
            if (remove_employer == null)
                return null;
            else
            {
                return new EmployerModel
                {
                    EmployerId = remove_employer.EmployerId,
                };
            }
        }

        EmployerModel IEmployerService.Employer(EmployerModel employerModel, string id)
        {
            var update_employer = new Employers
            {
                EmployerId = employerModel.EmployerId,
                CompanyName = employerModel.CompanyName,
                Details = employerModel.Details,
                PhoneNumber = employerModel.PhoneNumber,
                AlternatePhoneNumber = employerModel.AlternatePhoneNumber,
                Category = employerModel.Category,
            };

            var updated_employer = _employerDA.Employers(update_employer, id);
            return new EmployerModel
            {
                EmployerId = updated_employer.EmployerId
            };
        }
    }
}
