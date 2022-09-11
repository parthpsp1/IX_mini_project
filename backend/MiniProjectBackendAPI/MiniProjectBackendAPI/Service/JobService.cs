using MiniProjectBackendAPI.DataAccess;
using MiniProjectBackendAPI.Entity;
using MiniProjectBackendAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniProjectBackendAPI.Service
{
    public interface IJobService
    {
        IEnumerable<JobsModel> Jobs();
        JobsModel Jobs(int id);
        Task<JobsModel> Jobs(JobsModel jobsModel);
        JobsModel Jobs(JobsModel jobsModel, int id);
        JobsModel Remove(int id);
    }

    public class JobService : IJobService
    {
        private readonly IJobDA _jobDA;

        public JobService(IJobDA jobDA)
        {
            _jobDA = jobDA;
        }
        public IEnumerable<JobsModel> Jobs()
        {
            var get_all_jobs = _jobDA.Jobs();
            List<JobsModel> job_list = new();
            foreach(var element in get_all_jobs)
            {
                job_list.Add(new JobsModel 
                { 
                    JobID = element.JobID,
                    EmployerID = element.EmployerID,
                    Title = element.Title,
                    Address = element.Address,
                    Description = element.Description,
                    PayRange = element.PayRange,
                    PersonOfContact = element.PersonOfContact,
                });
            }
            return job_list;
        }

        public JobsModel Jobs(int id)
        {
            var get_job_by_id = _jobDA.Jobs(id);
            if (get_job_by_id == null)
                return null;
            else
            {
                return new JobsModel
                {
                    JobID = get_job_by_id.JobID,
                };
            }
        }

        public JobsModel Jobs(JobsModel jobsModel, int id)
        {
            var update_job = new Jobs
            {
                JobID = jobsModel.JobID,
                EmployerID = jobsModel.EmployerID,
                Title = jobsModel.Title,
                Address = jobsModel.Address,
                Description = jobsModel.Description,
                PayRange = jobsModel.PayRange,
                PersonOfContact = jobsModel.PersonOfContact,
            };

            var updated_job = _jobDA.Jobs(update_job, id);
            return new JobsModel
            {
                JobID = updated_job.JobID
            };
        }

        public async Task<JobsModel> Jobs(JobsModel jobsModel)
        {
            var new_job = new Jobs
            {
                JobID = jobsModel.JobID,
                EmployerID = jobsModel.EmployerID,
                Title = jobsModel.Title,
                Address = jobsModel.Address,
                Description = jobsModel.Description,
                PayRange = jobsModel.PayRange,
                PersonOfContact = jobsModel.PersonOfContact,
            };

            var add_new_job = await _jobDA.Jobs(new_job);
            return new JobsModel
            {
                JobID = add_new_job.JobID
            };
        }

        public JobsModel Remove(int id)
        {
            var remove_job = _jobDA.Remove(id);
            if (remove_job == null)
                return null;
            else
            {
                return new JobsModel
                {
                    JobID = remove_job.JobID,
                };
            }
        }
    }
}
