using Restaurant.Models;

namespace Restaurant.Domain;

class OrderService
{
    private RestaurantDataSet _dataSet;
    private OrderGenerator _orderGenerator;
    private OrderQueue _orderQueue;

    public OrderService(RestaurantDataSet dataSet, OrderGenerator orderGenerator, OrderQueue orderQueue)
    {
        _dataSet = dataSet;
        _orderGenerator = orderGenerator;
        _orderQueue = orderQueue;
    }

    public void CreateOrder()
    {
        var recipeToFollow = _orderGenerator.GetRandomRecipe(_dataSet.Recipes);

        var order = new Order
        {
            RecipeFollowed = recipeToFollow,
            CurrentStepIndex = 0,
            OrderProgress = 0,
        };

        _orderQueue.AddToQueue(order);

    }

    public void CompleteCurrentStep(Order order)
    {
        order.CurrentStepIndex++;
        order.OrderProgress = (double)order.CurrentStepIndex / order.RecipeFollowed.Steps.Count * 100;
    }

}