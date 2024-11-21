using GameStore.Data;
using GameStore.DTOs;
using GameStore.Entities;
using GameStore.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Endpoints;

public static class GameEndpoints
{
    const string GetGameEndpointName = "GetGame";

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {
        //Minimal API's

        // Common resource path. Route group builder.
        var group = app.MapGroup("games")
            .WithParameterValidation();

        // GET /games

        //Maps each retrieved record from an entity to a Summarydto
        //As no tracking when just return data. I iimproves performance
        group.MapGet("/", async (GameStoreContext dbContext) =>
            await dbContext.Games
                    .Include(game => game.Genre)
                    .Select(game => game.ToSummaryDTO())
                    .AsNoTracking()
                    .ToListAsync());


        // GET /games/1
        group.MapGet("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            //Will attempt to find the game within the context initially will try db afterwards.

            Game? game = await dbContext.Games.FindAsync(id);

            // Not found on null otherwise return okay status and game
            // Also Ensure IResult is return in both circumstances
            return game is null ?
                Results.NotFound() : Results.Ok(game.ToDetailsDTO());
        })
        .WithName(GetGameEndpointName);

        // POST /games
        group.MapPost("", async (CreateGameDTO newGame, GameStoreContext dbContext) =>
        {

            Game game = newGame.ToEntity();
            // game.Genre = dbContext.GGenres.Find(newGame.genreID);
            dbContext.Games.Add(game);

            // Converts new records to SQL insert query
            await dbContext.SaveChangesAsync();

            //Convert back to DTO (contract format with client) format before returning to client.
            GameDetailsDTO gameDTO = game.ToDetailsDTO();

            return Results.CreatedAtRoute(GetGameEndpointName, new { id = game.id}, gameDTO);
        })
        .WithParameterValidation();

        // Put /games
        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame, GameStoreContext dbContext) =>
        {
            var existingGame = await dbContext.Games.FindAsync(id);

            // If resource doesn't exist then return not found. Save issues with automated
            // id generation in SQL resource generation.
            if (existingGame is null)
            {
                return Results.NotFound();
            }

            dbContext.Entry(existingGame)
                .CurrentValues
                .SetValues(updatedGame.ToEntity(id));

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // Delete /games
        group.MapDelete("/{id}", async (int id, GameStoreContext dbContext) =>
        {
            //Batch delete. Rather than finding it then deleting
            await dbContext.Games.Where(game => game.id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });

        return group;
    }
}