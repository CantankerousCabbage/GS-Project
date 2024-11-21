using System.ComponentModel;
using GameStore.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Data;

// Options will provide details about connecting to the DB
class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> GGenres => Set<Genre>();

//  Only do do for simple data that is static and wont change
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Genre>().HasData(
            new { id = 1, name = "Fighting"},
            new { id = 2, name = "Sports"},
            new { id = 3, name = "Racing"},
            new { id = 4, name = "RP"},
            new { id = 5, name = "Family"}
        );
    }
}


