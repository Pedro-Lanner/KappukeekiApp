using Microsoft.EntityFrameworkCore;
using KappukeekiApp.Models;

namespace KappukeekiApp.Data {
    public class AppDbContext : DbContext {
        public DbSet<Cupcake> Cupcakes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<Pessoa> Pessoas { get;  set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet <Setor> Setores { get; set; }

        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseSqlite("Data Source=kappukeeki.db");
        }
    }
}