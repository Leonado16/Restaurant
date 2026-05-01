using System.Data;
using System.Linq;
using Restaurant.Domain;
using Restaurant.Models;

namespace Restaurant.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    public QueueViewModel Queue { get; }

    public MainWindowViewModel()
    {
        var orderQueue = new OrderQueue();
        var orderGenerator = new OrderGenerator();
        var dataSet = StaticData.RestaurantDataService.DataSet;
        var orderService = new OrderService(dataSet, orderGenerator, orderQueue);

        orderService.CreateOrder();
        Queue = new QueueViewModel(orderQueue);
        Queue.Refresh();
        
        var order = orderQueue.Snapshot().First();
    }
}
