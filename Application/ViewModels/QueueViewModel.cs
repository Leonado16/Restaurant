using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Restaurant.Domain;
using Restaurant.Models;

namespace Restaurant.ViewModels;

public partial class QueueViewModel : ViewModelBase
{
    private OrderQueue _orderQueue;
    
    [ObservableProperty]
    public ObservableCollection<OrderCardViewModel> _orderCards = new();

    public QueueViewModel(OrderQueue orderQueue)
    {
        _orderQueue = orderQueue;
        Refresh();
    }

    public void Refresh()
    {
        OrderCards.Clear();
        
        foreach (var order in _orderQueue.Snapshot())
        {
            OrderCards.Add(new OrderCardViewModel(order));
        }
    }

}