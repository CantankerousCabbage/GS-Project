using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs;

public record class UpdateGameDto(
   [Required][StringLength(50)] int id,
    string name,
    int genreID,
    [Range(0,100)] decimal price,
    DateOnly ReleaseDAte
);