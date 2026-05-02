using System.Collections.Generic;

namespace Restaurant.Models;

public class RestaurantDataSet
{
    public List<Recipe> Recipes { get; set; } = new();
    public List<Ingredient> Ingredients { get; set; } = new();
    public List<Station> Stations { get; set; } = new();
}