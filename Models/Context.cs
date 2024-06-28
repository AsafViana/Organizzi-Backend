using Microsoft.EntityFrameworkCore;

namespace Organizzi.Models
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Servicos> Servicos { get; set; }
    }
}
