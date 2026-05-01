using System.Collections.Generic;

namespace Restaurant.Models;

public class RestaurantDataSet
{
    public List<Recipe> Recipes { get; set; } = [];
    public List<Ingredient> Ingredients { get; set; } = [];
    public List<Station> Stations { get; set; } = [];
}