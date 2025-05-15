using Microsoft.EntityFrameworkCore;
using DistribuidoraAPI.Models;

namespace DistribuidoraAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}