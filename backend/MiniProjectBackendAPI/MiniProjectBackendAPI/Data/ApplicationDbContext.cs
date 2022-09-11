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

    }
}
