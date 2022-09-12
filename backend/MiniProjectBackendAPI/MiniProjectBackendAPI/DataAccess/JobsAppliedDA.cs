using MiniProjectBackendAPI.Data;
using MiniProjectBackendAPI.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MiniProjectBackendAPI.DataAccess
{
    public interface IJobsAppliedDA
    {
        IEnumerable<JobApplied> JobsApplied();
    }

    public class JobsAppliedDA : IJobsAppliedDA
    {
        private readonly JobPortalDbContext _context;

        public JobsAppliedDA(JobPortalDbContext context)
        {
            _context = context;
        }
        public IEnumerable<JobApplied> JobsApplied()
        {
            return _context.JobsApplied.ToList();
        }
    }
}
