using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Restaurant.Domain;
using Restaurant.Models;

namespace Restaurant.ViewModels;

public partial class OrderCardViewModel : ViewModelBase
{    
    [ObservableProperty]
    private string? _recipeFollowed;

    [ObservableProperty]
    private int _currentStepIndex;

    [ObservableProperty]
    private string _currentStepDisplay = "";

    [ObservableProperty]
    private double _orderProgress;
    public OrderCardViewModel(Order order)
    {
        RecipeFollowed = order.RecipeFollowed.Name; 
        CurrentStepIndex = order.CurrentStepIndex;
        OrderProgress = order.OrderProgress;

        if (order.CurrentStepIndex < order.RecipeFollowed.Steps.Count)
        {
            int displayNumber = order.CurrentStepIndex + 1;
            string stepText = order.RecipeFollowed.Steps[order.CurrentStepIndex].Step;
            CurrentStepDisplay = $"{displayNumber}. {stepText}";
        }
        else
        {
            CurrentStepDisplay = "Completed";
        }
    }
}
