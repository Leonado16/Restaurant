using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using Restaurant.Domain;
using Restaurant.Models;

namespace Restaurant.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public QueueViewModel Queue { get; }
    public ObservableCollection<StationViewModel> Stations { get; }
    public MainWindowViewModel()
    {
        var dataSet = StaticData.RestaurantDataService.DataSet;
        var orderGenerator = new OrderGenerator();
        var orderQueue = new OrderQueue();
        var orderService = new OrderService(dataSet, orderGenerator, orderQueue);

        // for starting
        orderService.CreateOrder();
        //
        Queue = new QueueViewModel(orderQueue);
        Stations = new ObservableCollection<StationViewModel>();
        foreach (var stationDefiniton in dataSet.Stations)
        {
            for (int i = 0; i < stationDefiniton.DefaultCount; i++)
            {
                var instance = new StationInstance(stationDefiniton.Type);
                var stationName = stationDefiniton.Type + " " + (i + 1);

                Stations.Add(new StationViewModel(stationName,instance, orderQueue, orderService, Queue)
                );
            }
        }
    }
}
