using System;
using System.Collections.Generic;
using Restaurant.Models;


namespace Restaurant.Domain;

public class OrderGenerator
{
    private Random _random = new();
    public Recipe GetRandomRecipe(List<Recipe> recipes)
    {
        int index = _random.Next(recipes.Count);
        return recipes[index];
    }
}

