using MiniProjectBackendAPI.Data;
using MiniProjectBackendAPI.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProjectBackendAPI.DataAccess
{
    public interface IJobDA
    {
        IEnumerable<Job> Jobs();
        Job Jobs(int id);
        Task<Job> Jobs(Job jobs);
        Job Jobs(Job jobs, int id);
        Job Remove(int id);
    }

    public class JobDA : IJobDA
    {
        private readonly JobPortalDbContext _context;

        public JobDA(JobPortalDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Job> Jobs()
        {
            return _context.Jobs.ToList();
        }

        public Job Jobs(int id)
        {
            return _context.Jobs.FirstOrDefault(element => element.JobID == id);
        }

        public async Task<Job> Jobs(Job jobs)
        {
            var add_job = await _context.Jobs.AddAsync(jobs);
            _context.SaveChanges();
            return add_job.Entity;
        }

        public Job Jobs(Job jobs, int id)
        {
            var update_job = _context.Jobs.Where(element => element.JobID == id).ToList();
            foreach(var element in update_job)
            {
                if(element.JobID == id)
                {
                    element.EmployerID = jobs.EmployerID;
                    element.Title = jobs.Title;
                    element.Description = jobs.Description;
                    element.PersonOfContact = jobs.PersonOfContact;
                    element.PayRange = jobs.PayRange;

                    var updated_job = _context.Jobs.Update(element);
                    _context.SaveChanges();
                    return updated_job.Entity;
                }
            }
            return jobs;
        }

        public Job Remove(int id)
        {
            var remove_job = _context.Jobs.Where(element => element.JobID == id).FirstOrDefault();
            if(remove_job.JobID == id)
            {
                _context.Jobs.Remove(remove_job);
                _context.SaveChanges();
                return remove_job;
            }
            return remove_job;
        }
    }
}
