using System.Collections.Generic;
using Restaurant.Models;

public interface IRestaurantDataService
{
    List<Recipe> GetRecipes();
    List<Ingredient> GetIngredients();
    List<Station> GetStations();
}