using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniProjectBackendAPI.Authentication;
using MiniProjectBackendAPI.Entity;

namespace MiniProjectBackendAPI.Data
{
    public class JobPortalDbContext : IdentityDbContext<AuthenticateUser>
    {
        public JobPortalDbContext(DbContextOptions<JobPortalDbContext> options) : base(options)
        {

        }
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobApplied> JobsApplied { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<JobApplied>().HasOne(e => e.Jobs).WithMany(ue => ue.JobsApplied)
                .HasForeignKey(e => e.JobID).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<JobApplied>().HasOne(e => e.Users).WithMany(ue => ue.JobsApplied)
                 .HasForeignKey(e => e.UserID);

            base.OnModelCreating(builder);
        }
    }
}
