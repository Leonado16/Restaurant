using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Restaurant.Domain;
using Restaurant.Models;

namespace Restaurant.ViewModels;

public partial class OrderCardViewModel : ViewModelBase
{  
    [ObservableProperty]
    private string _currentStepDisplay = "";

    [ObservableProperty]
    private Order? _order;
    
    public OrderCardViewModel(Order order)
    {
        Order = order;
        CurrentStepDisplay = GetStepText();
    }

    private string GetStepText()
    {

        if (Order == null || Order.CurrentStepIndex >= Order.RecipeFollowed.Steps.Count)
        {
            return "Completed";
        }
    
        int displayNumber = Order.CurrentStepIndex + 1;
        string stepText = Order.RecipeFollowed.Steps[Order.CurrentStepIndex].Step;
        return $"{displayNumber}. {stepText}";
    }
}
