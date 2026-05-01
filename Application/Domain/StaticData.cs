using Restaurant.Models;
using Restaurant.Persistence;

namespace Restaurant.Domain;

public static class StaticData
{
    public static RestaurantDataService RestaurantDataService { get; } = new();

    // public static UserPreferences UserPreferences { get; set; } = new();
    public static JSONPersistence Persistence { get; } = new();
}