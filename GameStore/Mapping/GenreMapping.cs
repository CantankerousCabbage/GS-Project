using GameStore.DTOs;
using GameStore.Entities;

namespace GameStore.Dtos;

public static class GenreMapping
{
    public static GenreDto ToDto(this Genre genre )
    {
        return new GenreDto(genre.id, genre.name);
    }
}

