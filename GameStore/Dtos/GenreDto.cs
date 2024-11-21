using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs;

public record class GenreDto(
    int id,
    string name
);


