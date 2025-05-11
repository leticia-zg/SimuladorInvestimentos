using Microsoft.EntityFrameworkCore;
using SimuladorInvestimentos.Core.Models;


namespace SimuladorInvestimentos.Data.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Investimento> Investimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais de mapeamento podem ser feitas aqui
            modelBuilder.Entity<Investimento>().ToTable("INVESTIMENTOS");
        }
    }
}
