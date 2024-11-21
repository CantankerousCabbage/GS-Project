namespace GameStore.Entities;

public class Genre
{
    public int id { get; set; }

    // Required keyword to specify that name must be used rather than name?
    public required string name { get; set; }
}