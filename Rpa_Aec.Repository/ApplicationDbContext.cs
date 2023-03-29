using Microsoft.EntityFrameworkCore;
using Rpa_Aec.Domain.Entities;

namespace Rpa_Aec.Repository
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<Busca> Buscas { get; set; }

    }
}
