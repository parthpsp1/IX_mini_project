using MiniProjectBackendAPI.DataAccess;
using MiniProjectBackendAPI.Model;
using System.Collections.Generic;

namespace MiniProjectBackendAPI.Service
{
    public interface IJobsAppliedService
    {
        IEnumerable<JobsAppliedModel> JobsApplied();
    }

    public class JobsAppliedService : IJobsAppliedService
    {
        private readonly IJobsAppliedDA _jobsAppliedDA;

        public JobsAppliedService(IJobsAppliedDA jobsAppliedDA)
        {
            _jobsAppliedDA = jobsAppliedDA;
        }
        public IEnumerable<JobsAppliedModel> JobsApplied()
        {
            var get_all_jobs_applied = _jobsAppliedDA.JobsApplied();
            List<JobsAppliedModel> applied_job_list = new();
            foreach(var element in get_all_jobs_applied)
            {
                applied_job_list.Add(new JobsAppliedModel
                {
                    JobsAppliedID = element.JobsAppliedID,
                    JobID = element.JobID,
                    UserID = element.UserID,
                    Status = element.Status
                });
            }
            return applied_job_list;
        }
    }
}
