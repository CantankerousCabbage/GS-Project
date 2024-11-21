using System.ComponentModel.DataAnnotations;

namespace GameStore.DTOs;

public record class GameSummaryDTO(
    int id,
    [Required][StringLength(50)] string name,
    [Required][StringLength(25)] string genre,
    [Required][Range(0, 200)] decimal price,
    DateOnly ReleaseDAte
);


