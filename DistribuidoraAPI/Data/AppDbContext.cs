using Microsoft.EntityFrameworkCore;
using DistribuidoraAPI.Models;


namespace DistribuidoraAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
        public DbSet<ProdutoFornecedor> ProdutosFornecedor { get; set; } //--> é uma sub tabela de fornecedor que detem os produtos cadastrado
        public DbSet<PedidoFornecedor> PedidosFornecedor { get; set; } //--> é uma sub tabela de distribuidora para os pedidos dos produtos do fornecedor  
        public DbSet<Produto> Produtos { get; set; } 


        public DbSet<CarrinhoDeCompra> CarrinhoDeCompras { get; set; }


        //--- usuários que tem login para baixo 
        public DbSet<Login> Login { get; set; }
        public DbSet<Distribuidora> Distribuidora { get; set; }
        public DbSet<Fornecedor> Fornecedor { get; set; } 
        public DbSet<Entregador> Entregador { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
    }
}