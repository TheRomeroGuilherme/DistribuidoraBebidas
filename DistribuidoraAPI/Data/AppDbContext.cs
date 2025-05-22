using Microsoft.EntityFrameworkCore;
using DistribuidoraAPI.Models;

namespace DistribuidoraAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Fornecedor> Suppliers { get; set; }
    public DbSet<Vendedor> Sellers { get; set; }
    public DbSet<Cliente> Customers { get; set; }
    public DbSet<Produto> Products { get; set; }
    public DbSet<CarrinhoDeCompra> Carts { get; set; }
    public DbSet<Venda> Sales { get; set; }
    public DbSet<VenderItem> SaleItems { get; set; }
    }
}