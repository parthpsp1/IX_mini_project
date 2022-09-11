using MiniProjectBackendAPI.Data;
using MiniProjectBackendAPI.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MiniProjectBackendAPI.DataAccess
{
    public interface IJobsAppliedDA
    {
        IEnumerable<JobsApplied> JobsApplied();
    }

    public class JobsAppliedDA : IJobsAppliedDA
    {
        private readonly ApplicationDbContext _context;

        public JobsAppliedDA(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<JobsApplied> JobsApplied()
        {
            return _context.JobsApplied.ToList();
        }
    }
}
