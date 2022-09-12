using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiniProjectBackendAPI.Authentication;
using MiniProjectBackendAPI.Entity;

namespace MiniProjectBackendAPI.Data
{
    public class ApplicationDbContext : IdentityDbContext<AuthenticateUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employers> Employers { get; set; }
        public DbSet<Jobs> Jobs { get; set; }
        public DbSet<JobsApplied> JobsApplied { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<JobsApplied>().HasOne(e => e.Jobs).WithMany(ue => ue.JobsApplied)
                .HasForeignKey(e => e.JobID).OnDelete(DeleteBehavior.Cascade);

            builder.Entity<JobsApplied>().HasOne(e => e.Users).WithMany(ue => ue.JobsApplied)
                 .HasForeignKey(e => e.UserID);

            base.OnModelCreating(builder);
        }
    }
}
