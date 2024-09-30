using ApiClientsDDD.Domain.Models;
using ApiClientsDDD.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace ApiClientsDDD.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da entidade Client
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(c => c.Id);

                entity.Property(c => c.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(c => c.Age)
                    .IsRequired();

                entity.Property(c => c.RegistrationDate)
                    .IsRequired();

                // Relacionamento entre Client e Address
                entity.HasMany(c => c.Addresses)
                    .WithOne(a => a.Client)
                    .HasForeignKey(a => a.ClientId)
                    .OnDelete(DeleteBehavior.Cascade); // Delete em cascata
            });

            // Configuração da entidade Address
            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasKey(a => a.Id);

                entity.Property(a => a.Street)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(a => a.City)
                    .HasMaxLength(100);

                entity.Property(a => a.Number)
                    .HasMaxLength(10);

                entity.Property(a => a.AddressType)
                    .IsRequired();
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
