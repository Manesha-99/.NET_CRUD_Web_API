using Microsoft.EntityFrameworkCore;

namespace Web_API.Data
{
    public class VideoGameDbContext(DbContextOptions<VideoGameDbContext> options) : DbContext(options)
    {
        public DbSet<VideoGame> VideoGames => Set<VideoGame>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<VideoGame>().HasData(
                new VideoGame
                {
                    Id = 1,
                    Title = "Red Dead Redemption II",
                    Platform = "Current Gen Consoles and PC",
                    Developer = "Rockstar Games",
                    Publisher = "Take Two Interactive"
                },
                new VideoGame
                {
                    Id = 2,
                    Title = "Farcry 2",
                    Platform = "PC and old consoles",
                    Developer = "Ubisoft",
                    Publisher = "Ubisoft"
                },
                new VideoGame
                {
                    Id = 3,
                    Title = "Detroit Become Human",
                    Platform = "PC and Playstation",
                    Developer = "Quantam Dream",
                    Publisher = "Sony Interactive Games"
                },
                new VideoGame
                {
                    Id = 4,
                    Title = "Mafia II",
                    Platform = "PC and old consoles",
                    Developer = "2K Games",
                    Publisher = "Take Two Interactive"
                }

            );

        }
        }

    }

    

