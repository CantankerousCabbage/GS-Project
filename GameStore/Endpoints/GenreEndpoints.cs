using GameStore.Data;
using GameStore.Dtos;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Endpoints;

public static class GenreEndpoints
{
    public static RouteGroupBuilder MapGenresEndpoints(this WebApplication app)
    {
       var group = app.MapGroup("genres");

       group.MapGet("/", async (GameStoreContext dbContext) =>
        await dbContext.GGenres
                        .Select(genre => genre.ToDto())
                        .AsNoTracking()
                        .ToListAsync());

        return group;
    }
}
