using System;
using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Restaurant.Domain;
using Restaurant.Models;



namespace Restaurant.ViewModels;

public partial class StationViewModel : ViewModelBase
{
    private string _stationName;
    private StationInstance _station;
    private OrderQueue _queue;
    private OrderService _orderService;
    private QueueViewModel _queueViewModel;

    public string StationType => _stationName;


    public StationViewModel(
            string stationName,
            StationInstance station,
            OrderQueue queue,
            OrderService orderService,
            QueueViewModel queueViewModel)
    {
        _stationName = stationName;
        _station = station;
        _queue = queue;
        _orderService = orderService;
        _queueViewModel = queueViewModel;
    }


    [ObservableProperty]
    private bool isBusy;

    [RelayCommand(CanExecute = nameof(CanExecuteStep))]
    private async Task ExecuteStep()
    {
        var order = FindExecutableOrder();

        if (order == null)
        {
            return;
        }

        order.CurrentWorkstation = _stationName;

        IsBusy = true;
        _station.IsBusy = true;

        var step = order.RecipeFollowed.Steps[order.CurrentStepIndex];

        int delay = step.Duration * 100;
        double stepsize = 1.0 / (order.RecipeFollowed.Steps.Count * step.Duration);
        while(delay >= 0)
        {
            await Task.Delay(10);
            order.OrderProgress += stepsize;
            delay--;
            _queueViewModel.Refresh();
        }
        
        order.CurrentWorkstation = "";
        _orderService.CompleteCurrentStep(order);

        if (new Random().Next(100) < 20 || order.CurrentStepIndex >= order.RecipeFollowed.Steps.Count)
            _orderService.CreateOrder();
        
        _queueViewModel.Refresh();

        _station.IsBusy = false;
        IsBusy = false;
    }

    private bool CanExecuteStep()
    {
        if (IsBusy)
        {
            return false;
        }

        return FindExecutableOrder() != null;
    }

    private Order? FindExecutableOrder()
    {
        return _queue.Snapshot().FirstOrDefault(order =>
        string.IsNullOrEmpty(order.CurrentWorkstation) &&
        order.CurrentStepIndex < order.RecipeFollowed.Steps.Count &&
        order.RecipeFollowed.Steps[order.CurrentStepIndex].StationType == _station.Type);
    }
}
