using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs;

public record class CreateGameDTO(
    [Required][StringLength(50)] string name,
    int genreID,
    [Required][Range(0, 200)] decimal price,
    DateOnly ReleaseDAte
);