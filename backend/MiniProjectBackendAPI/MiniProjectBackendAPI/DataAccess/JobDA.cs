using MiniProjectBackendAPI.Data;
using MiniProjectBackendAPI.Entity;
using System.Collections.Generic;
using System.Linq;

namespace MiniProjectBackendAPI.DataAccess
{
    public interface IJobDA
    {
        IEnumerable<Job> Jobs();
        Job Job(int id);
        int Job(Job jobs);
        bool UpdateJob(Job jobs);
        bool Remove(int id);
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

        public Job Job(int id)
        {
            return _context.Jobs.FirstOrDefault(element => element.JobId == id);
        }

        public int Job(Job job)
        {
            _context.Jobs.Add(job);
            _context.SaveChanges();
            return job.JobId;
        }

        public bool UpdateJob(Job job)
        {
            var existingJob = _context.Jobs.FirstOrDefault(element => element.JobId == job.JobId);
            if(existingJob != null)
            {
                existingJob.EmployerId = job.EmployerId;
                existingJob.Title = job.Title;
                existingJob.Description = job.Description;
                existingJob.Address = job.Address;
                existingJob.PersonOfContact = job.PersonOfContact;
                existingJob.PayRange = job.PayRange;
                _context.SaveChanges();
                return true;
            }
            else
            {
            return false;
            }
        }

        public bool Remove(int id)
        {
            var removeJob = _context.Jobs.FirstOrDefault(element => element.JobId == id);
            if(removeJob != null)
            {
                _context.Jobs.Remove(removeJob);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
