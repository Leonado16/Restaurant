using System.Collections.Generic;

namespace Restaurant.Models;

public class Recipe
{
    public required string Name { get; set; }
    public required string Difficulty { get; set; }
    public required double SalePrice { get; set; }
    public required List<RequiredIngredient> RequiredIngredients { get; set; } = new();
    public required List<RecipeStep> Steps { get; set; } = new();
}