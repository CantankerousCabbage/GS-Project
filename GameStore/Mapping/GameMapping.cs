using GameStore.DTOs;
using GameStore.Entities;

namespace GameStore.Mapping;

public static class GameMapping
{
      public static Game ToEntity(this CreateGameDTO game)
      {
        return new Game()
        {
                name = game.name,
                GenreId = game.genreID,
                Price = game.price,
                ReleaseDAte = game.ReleaseDAte
        };
      }

      public static Game ToEntity(this UpdateGameDto game, int id)
      {
        return new Game()
        {
                id = id,
                name = game.name,
                GenreId = game.genreID,
                Price = game.price,
                ReleaseDAte = game.ReleaseDAte
        };
      }

      public static GameSummaryDTO ToSummaryDTO(this Game game)
      {
        return new(
            game.id,
            game.name,
            game.Genre!.name,
            game.Price,
            game.ReleaseDAte
        );
      }

      public static GameDetailsDTO ToDetailsDTO(this Game game)
      {
        return new(
            game.id,
            game.name,
            game.GenreId,
            game.Price,
            game.ReleaseDAte
        );
      }
}