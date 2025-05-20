using Microsoft.EntityFrameworkCore;
using VetClinicManagement.Models;

namespace VetClinicManagement.Data
{
    public class VetClinicContext : DbContext
    {
        public VetClinicContext(DbContextOptions<VetClinicContext> options) : base(options)
        {
        }

        public DbSet<Animal> Animals { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Procedimento> Procedimentos { get; set; }
        public DbSet<Atendimento> Atendimentos { get; set; }
        public DbSet<AtendimentoProcedimento> AtendimentoProcedimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AtendimentoProcedimento>()
                .HasOne(ap => ap.Atendimento)
                .WithMany(a => a.AtendimentoProcedimentos)
                .HasForeignKey(ap => ap.AtendimentoId);

            modelBuilder.Entity<AtendimentoProcedimento>()
                .HasOne(ap => ap.Procedimento)
                .WithMany()
                .HasForeignKey(ap => ap.ProcedimentoId);
        }
    }
}

