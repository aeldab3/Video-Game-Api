using Microsoft.EntityFrameworkCore;
using VideoGameApi.Models;

namespace VideoGameApi.Data
{
    public class VideoGameDbContext : DbContext
    {
        public VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : base(options){}
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame { Id = 1, Title = "Spider-Man 2", Platform = "PS5", Developer = "Insomniac Games", Publisher = "Sony Interactive Entertainment" },
                new VideoGame { Id = 2, Title = "God of War", Platform = "PS4", Developer = "Santa Monica Studio", Publisher = "Sony Interactive Entertainment" },
                new VideoGame { Id = 3, Title = "Minecraft", Platform = "Multi-platform", Developer = "Mojang Studios", Publisher = "Mojang Studios" }
            );
        }
    }
}
