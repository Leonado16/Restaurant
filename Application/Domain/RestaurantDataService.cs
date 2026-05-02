using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Restaurant.Models;
using Restaurant.Persistence;

namespace Restaurant.Domain;

public class RestaurantDataService : IRestaurantDataService
{
    public RestaurantDataSet _dataSet = new();
    public RestaurantDataSet DataSet => _dataSet;

    public void LoadData()
    {
        Console.WriteLine("LoadData");
        var loaded = StaticData.Persistence.Load<RestaurantDataSet>("Recipes.json");

        _dataSet.Recipes = loaded.Recipes;
        _dataSet.Ingredients = loaded.Ingredients;
        _dataSet.Stations = loaded.Stations;
    }

    public List<Recipe> GetRecipes() => _dataSet.Recipes;
    public List<Ingredient> GetIngredients() => _dataSet.Ingredients;
    public List<Station> GetStations() => _dataSet.Stations;
}
    