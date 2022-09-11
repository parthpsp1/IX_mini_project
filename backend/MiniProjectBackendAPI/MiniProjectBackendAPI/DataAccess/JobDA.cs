using MiniProjectBackendAPI.Data;
using MiniProjectBackendAPI.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MiniProjectBackendAPI.DataAccess
{
    public interface IJobDA
    {
        IEnumerable<Jobs> Jobs();
        Jobs Jobs(int id);
        Task<Jobs> Jobs(Jobs jobs);
        Jobs Jobs(Jobs jobs, int id);
        Jobs Remove(int id);
    }

    public class JobDA : IJobDA
    {
        private readonly ApplicationDbContext _context;

        public JobDA(ApplicationDbContext context)
        {
            _context = context;
        }
        public IEnumerable<Jobs> Jobs()
        {
            return _context.Jobs.ToList();
        }

        public Jobs Jobs(int id)
        {
            return _context.Jobs.FirstOrDefault(element => element.JobID == id);
        }

        public async Task<Jobs> Jobs(Jobs jobs)
        {
            var add_job = await _context.Jobs.AddAsync(jobs);
            _context.SaveChanges();
            return add_job.Entity;
        }

        public Jobs Jobs(Jobs jobs, int id)
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

        public Jobs Remove(int id)
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
