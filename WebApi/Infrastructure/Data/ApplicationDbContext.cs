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

        public DbSet<DogBreed> DogBreed { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<DogBreed>(entity =>
            {
                entity.HasKey(e => e.DogId);

                entity.Property(e => e.Name)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

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
