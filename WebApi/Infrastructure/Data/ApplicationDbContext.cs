using Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<DogBreed> DogBreeds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DogBreed>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasMaxLength(100);

                entity.Property(propertyExpression: e => e.Hypoallergenic)
                    .IsRequired();

                entity.Property(propertyExpression: e => e.MinLife)
                    .IsRequired();
                
                entity.Property(propertyExpression: e => e.MaxLife)
                    .IsRequired();


            });
        }
    }
}
