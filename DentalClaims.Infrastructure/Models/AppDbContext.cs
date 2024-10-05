using Microsoft.EntityFrameworkCore;
using DentalClaims.Domain.Models;

namespace DentalClaims.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<ConsultaOdontologica> Consultas { get; set; }
        public DbSet<Tratamento> Tratamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Usuario>()
                .HasMany(u => u.Consultas)
                .WithOne(c => c.Usuario)
                .HasForeignKey(c => c.UsuarioId);

            modelBuilder.Entity<ConsultaOdontologica>()
                .HasMany(c => c.Tratamentos)
                .WithOne(t => t.Consulta)
                .HasForeignKey(t => t.ConsultaId);

            modelBuilder.Entity<Tratamento>()
                .Property(t => t.Custo)
                .HasColumnType("DECIMAL(18, 2)");
        }
    }
}
