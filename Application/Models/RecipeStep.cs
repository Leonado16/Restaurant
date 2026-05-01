namespace Restaurant.Models;

public class RecipeStep
{
    public required string Step { get; set; }
    public required int Duration { get; set; }
    public required string StationType { get; set; }
}