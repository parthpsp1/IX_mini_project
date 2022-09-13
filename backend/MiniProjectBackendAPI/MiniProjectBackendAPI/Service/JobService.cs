using MiniProjectBackendAPI.DataAccess;
using MiniProjectBackendAPI.Entity;
using MiniProjectBackendAPI.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MiniProjectBackendAPI.Service
{
    public interface IJobService
    {
        IEnumerable<Jobs> Jobs();
        Jobs Job(int id);
        int Job(Jobs job);
        bool UpdateJob(Jobs job);
        bool Remove(int id);
    }

    public class JobService : IJobService
    {
        private readonly IJobDA _jobDA;

        public JobService(IJobDA jobDA)
        {
            _jobDA = jobDA;
        }

        public IEnumerable<Jobs> Jobs()
        {
            var getAllJobs = _jobDA.Jobs();
            List<Jobs> jobList = new();
            foreach(var element in getAllJobs)
            {
                jobList.Add(new Jobs 
                { 
                    JobId = element.JobId,
                    EmployerId = element.EmployerId,
                    Title = element.Title,
                    Address = element.Address,
                    Description = element.Description,
                    PayRange = element.PayRange,
                    PersonOfContact = element.PersonOfContact,
                });
            }
            return jobList;
        }

        public Jobs Job(int id)
        {
            var existingJob = _jobDA.Job(id);
            if (existingJob == null)
                return null;
            else
            {
                return new Jobs
                {
                    JobId = existingJob.JobId,
                    Title = existingJob.Title,
                    Description = existingJob.Description,
                    Address = existingJob.Address,
                    PersonOfContact = existingJob.PersonOfContact,
                    PayRange = existingJob.PayRange,
                    EmployerId = existingJob.EmployerId,
                };
            }
        }

        public int Job(Jobs job)
        {
            var newJob = new Job
            {
                EmployerId = job.EmployerId,
                Title = job.Title,
                Address = job.Address,
                Description = job.Description,
                PayRange = job.PayRange,
                PersonOfContact = job.PersonOfContact,
            };

        _jobDA.Job(newJob);
        return 0;
        }

        public bool UpdateJob(Jobs job)
        {
            var updatedJob = new Job
            {
                JobId = job.JobId,
                EmployerId = job.EmployerId,
                Title = job.Title,
                Address = job.Address,
                Description = job.Description,
                PayRange = job.PayRange,
                PersonOfContact = job.PersonOfContact,
            };
            _jobDA.UpdateJob(updatedJob);
            return true;
        }

        public bool Remove(int id)
        {
            var removeJob = _jobDA.Remove(id);
            if (removeJob)
                return true;
            return false;
        }
    }
}
