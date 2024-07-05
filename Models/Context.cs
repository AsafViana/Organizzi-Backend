using Microsoft.EntityFrameworkCore;

namespace Organizzi.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Services> Services { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Locations> Locations { get; set; }
        public DbSet<Workers> Workers { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<LoginInformations> LoginInformations { get; set; }
    }
}
