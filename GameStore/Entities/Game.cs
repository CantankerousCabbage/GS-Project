namespace GameStore.Entities;

public class Game
{
    public int id { get; set; }

    // Required keyword to specify that name must be used rather than name?
    public required string name { get; set; }

    // One to one association between game and genre
        public int GenreId { get; set; }

    // Genre may be null
    public Genre? Genre { get; set; }

    public decimal Price { get; set; }

    public DateOnly ReleaseDAte { get; set; }
}