namespace Restaurant.Models;

public class Order
{
    public required Recipe RecipeFollowed { get; set; }
    public int CurrentStepIndex { get; set; }
    public string CurrentWorkstation { get; set; } = "";
    public double OrderProgress { get; set; }

}