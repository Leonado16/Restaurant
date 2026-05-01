
namespace Restaurant.Models;

public class Ingredient
{
    public required string Name { get; set; }
    public required int InitialStock { get; set; }
    public required string Unit { get; set; }
    public required double Cost { get; set; }

}