using Microsoft.EntityFrameworkCore;

namespace MyPlants.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Plant> Plants { get; set; }
        public DbSet<Watering> Waterings { get; set; }

        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite key
            modelBuilder.Entity<Watering>()
                .HasKey(w => new { w.PlantId, w.Date });

            // Delete waterings when a plant is deleted
            modelBuilder.Entity<Watering>()
                    .HasOne(w => w.Plant)
                    .WithMany(p => p.Waterings)
                    .HasForeignKey(w => w.PlantId)
                    .OnDelete(DeleteBehavior.Cascade);

            // Index
            modelBuilder.Entity<Plant>()
                .HasIndex(p => p.UserId);

            // Seed
            string userId = "Gwa7mEmjuQcMQ2EepQHg3KyHGtg2";

            modelBuilder.Entity<Plant>().HasData(
                new Plant { Id = 1, Name = "Kitchen ficus", WaterFrequency = 10, ImageName = "1", BackgroundColorHex = "#FFD3AD", UserId = userId },
                new Plant { Id = 2, Name = "Bedroom ficus", WaterFrequency = 10, ImageName = "1", BackgroundColorHex = "#8BC7FF", UserId = userId },
                new Plant { Id = 3, Name = "Ficus tineke", WaterFrequency = 10, ImageName = "1", BackgroundColorHex = "#ECFFAD", UserId = userId },
                new Plant { Id = 4, Name = "Jade plant", WaterFrequency = 14, ImageName = "6", BackgroundColorHex = "#FFADDE", UserId = userId },
                new Plant { Id = 5, Name = "Peace lilly", WaterFrequency = 10, ImageName = "8", BackgroundColorHex = "#E7F3DC", UserId = userId },
                new Plant { Id = 6, Name = "Pothos", WaterFrequency = 10, ImageName = "3", BackgroundColorHex = "#FFA8A8", UserId = userId },
                new Plant { Id = 7, Name = "Sanseveria", WaterFrequency = 14, ImageName = "2", BackgroundColorHex = "#FFF79D", UserId = userId },
                new Plant { Id = 8, Name = "ZZ plant", WaterFrequency = 10, ImageName = "4", BackgroundColorHex = "#FFA8A8", UserId = userId }
            );

            modelBuilder.Entity<Watering>().HasData(
                new Watering { PlantId = 1, Date = new DateTime(2024, 12, 3) },
                new Watering { PlantId = 2, Date = new DateTime(2024, 12, 10) },
                new Watering { PlantId = 3, Date = new DateTime(2024, 12, 11) },
                new Watering { PlantId = 4, Date = new DateTime(2024, 12, 5) },
                new Watering { PlantId = 5, Date = new DateTime(2024, 12, 15) },
                new Watering { PlantId = 6, Date = new DateTime(2024, 12, 14) },
                new Watering { PlantId = 7, Date = new DateTime(2024, 12, 14) },
                new Watering { PlantId = 8, Date = new DateTime(2024, 12, 19) }
            );
        }
    }
}
