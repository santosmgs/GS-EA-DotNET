using EnergyAwareness.Models;
using Microsoft.EntityFrameworkCore;

namespace EnergyAwareness.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Eletronico> Eletronicos { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Valor> Valores { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mapeamento das tabelas para garantir que o EF entenda as entidades
            modelBuilder.Entity<Usuario>().ToTable("T_EA_USUARIO");
            modelBuilder.Entity<Eletronico>().ToTable("T_EA_ELETRONICOS");
            modelBuilder.Entity<Consulta>().ToTable("T_EA_CONSULTAS");
            modelBuilder.Entity<Valor>().ToTable("T_EA_VALORES");

            // Configura a chave primária das entidades
            modelBuilder.Entity<Usuario>()
                .HasKey(u => u.IdUsuario);

            modelBuilder.Entity<Eletronico>()
                .HasKey(e => e.IdEletronico);

            modelBuilder.Entity<Consulta>()
                .HasKey(c => c.IdConsultas);

            modelBuilder.Entity<Valor>()
                .HasKey(v => v.NrPotencia);
        }
    }
}