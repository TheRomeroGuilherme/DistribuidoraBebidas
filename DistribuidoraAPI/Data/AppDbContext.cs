using Microsoft.EntityFrameworkCore;
using DistribuidoraAPI.Models;

namespace DistribuidoraAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<ProdutoFornecedor> ProdutosFornecedor { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Produto> Products { get; set; }
        public DbSet<CarrinhoDeCompra> CarrinhoDeCompras { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<VenderItem> VenderItems { get; set; }
    }
}