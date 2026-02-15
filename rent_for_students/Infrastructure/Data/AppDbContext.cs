using rent_for_students.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace rent_for_students.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<HousingListing> HousingListings => Set<HousingListing>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<HousingListing>(entity =>
            {
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Title)
                      .HasMaxLength(120)
                      .IsRequired();

                entity.Property(x => x.City)
                      .HasMaxLength(120)
                      .IsRequired();

                entity.Property(x => x.Description)
                      .HasMaxLength(2000);

                entity.Property(x => x.District)
                      .HasMaxLength(120);

                entity.Property(x => x.PricePerMonth)
                      .HasPrecision(12, 2); // money-like

                entity.HasIndex(x => x.City);
                entity.HasIndex(x => x.PricePerMonth);
                entity.HasIndex(x => x.IsActive);
            });
        }
    }
}
