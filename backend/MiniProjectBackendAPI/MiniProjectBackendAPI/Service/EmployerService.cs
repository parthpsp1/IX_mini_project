using MiniProjectBackendAPI.DataAccess;
using System.Collections.Generic;
using System.Threading.Tasks;
using MiniProjectBackendAPI.Data;

namespace MiniProjectBackendAPI.Service
{
    public interface IEmployerService
    {
        IEnumerable<Model.Employer> Employers();
        Model.Employer Employer(string id);
        Task<Model.Employer> Employer(Model.Employer employerModel);

        Model.Employer Employer(Model.Employer employerModel, string id);
        Model.Employer Remove(string id);
    }

    public class EmployerService : IEmployerService
    {
        private readonly IEmployerDA _employerDA;

        public EmployerService(IEmployerDA employerDA)
        {
            _employerDA = employerDA;
        }
        public IEnumerable<Model.Employer> Employers()
        {
            var get_all_employers = _employerDA.Employer();
            List<Model.Employer> employer_list = new();
            foreach(var element in get_all_employers)
            {
                employer_list.Add(new Model.Employer
                {
                    EmployerId = element.EmployerId,
                    CompanyName = element.CompanyName,
                    Details = element.Details,
                    PhoneNumber = element.PhoneNumber,
                    AlternatePhoneNumber = element.AlternatePhoneNumber,
                    Category = element.Category
                });
            }
            return employer_list;
        }
        public Model.Employer Employer(string id)
        {
            var get_employer_by_id = _employerDA.Employers(id);
            if (get_employer_by_id == null)
                return null;
            else
            {
                return new Model.Employer
                {
                    EmployerId = get_employer_by_id.EmployerId,
                };
            }
        }

        public async Task<Model.Employer> Employer(Model.Employer employerModel)
        {
            var new_employer = new Entity.Employer
            {
                EmployerId = employerModel.EmployerId,
                CompanyName = employerModel.CompanyName,
                Details = employerModel.Details,
                PhoneNumber = employerModel.PhoneNumber,
                AlternatePhoneNumber = employerModel.AlternatePhoneNumber,
                Category = employerModel.Category
            };

            var add_new_employer = await _employerDA.Employers(new_employer);
            return new Model.Employer
            {
                EmployerId = add_new_employer.EmployerId
            };
        }


        public Model.Employer Remove(string id)
        {
            var remove_employer = _employerDA.Remove(id);
            if (remove_employer == null)
                return null;
            else
            {
                return new Model.Employer
                {
                    EmployerId = remove_employer.EmployerId,
                };
            }
        }

        Model.Employer IEmployerService.Employer(Model.Employer employerModel, string id)
        {
            var update_employer = new Entity.Employer
            {
                EmployerId = employerModel.EmployerId,
                CompanyName = employerModel.CompanyName,
                Details = employerModel.Details,
                PhoneNumber = employerModel.PhoneNumber,
                AlternatePhoneNumber = employerModel.AlternatePhoneNumber,
                Category = employerModel.Category,
            };

            var updated_employer = _employerDA.Employers(update_employer, id);
            return new Model.Employer
            {
                EmployerId = updated_employer.EmployerId
            };
        }
    }
}
