using System.Linq;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Restaurant.Domain;
using Restaurant.Models;



namespace Restaurant.ViewModels;

public partial class StationViewModel : ViewModelBase
{
    private StationInstance _station;
    private OrderQueue _queue;
    private OrderService _orderService;
    private QueueViewModel _queueViewModel;

    public string StationType => _station.Type;


    public StationViewModel(
            StationInstance station,
            OrderQueue queue,
            OrderService orderService,
            QueueViewModel queueViewModel)
    {
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

        IsBusy = true;
        _station.IsBusy = true;

        var step = order.RecipeFollowed.Steps[order.CurrentStepIndex];

        await Task.Delay(step.Duration * 1000);

        _orderService.CompleteCurrentStep(order);
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
        order.CurrentStepIndex < order.RecipeFollowed.Steps.Count &&
        order.RecipeFollowed.Steps[order.CurrentStepIndex].StationType == _station.Type);
    }
}

// [RelayCommand]
// public void Search()
// {
//     if (SelectedAirport is null)
//     {
//         return;
//     }

//     StaticData.UserPreferences.SelectedAirport = SelectedAirport;

//     _ = MoveTo(SelectedAirport);
//     DrawMarkers();
// }

// [RelayCommand]
// public void Clear()
// {
//     SelectedAirport = null;
//     StaticData.UserPreferences.SelectedAirport = SelectedAirport;
//     DrawMarkers();
// }

// private async Task MoveTo(Airport airport)
// {
//     Map.Navigator.CenterOn(MPConvert(airport.Longitude, airport.Latitude), 200);
//     await Task.Delay(200);
//     Map.Navigator.ZoomTo(5000, 200);
// }

// private void OnMarkerClicked(object? sender, MapInfoEventArgs e)
// {
//     var mapInfo = e.GetMapInfo(_markers);
//     if (mapInfo?.Feature is PointFeature clickedFeature)
//     {
//         var label = clickedFeature["Label"]?.ToString();

//         foreach (Airport airport in Airports)
//         {
//             if (airport.IataCode == label)
//             {
//                 _ = MoveTo(airport);
//                 SelectedAirport = airport;
//                 StaticData.UserPreferences.SelectedAirport = SelectedAirport;
//                 break;
//             }
//         }
//     }
//     DrawMarkers();
// }

// private MPoint MPConvert(double x, double y)
// {
//     return SphericalMercator.FromLonLat(x, y).ToMPoint();
// }

//     private void AddPin(MPoint point, string name, string color = "#588098")
//     {
//         ImageStyle im = new()
//         {
//             SymbolScale = 0.30,
//             Image = new()
//             {
//                 Source = "svg-content://<svg height=\"100\" width=\"100\" xmlns=\"http://www.w3.org/2000/svg\"><circle r=\"40\" cx=\"50\" cy=\"50\" fill=\"none\" stroke=\"red\" stroke-width=\"10\" /><circle r=\"0.1\" cx=\"50\" cy=\"50\" stroke-width=\"40\" stroke=\"red\" /></svg>",
//                 SvgStrokeColor = Color.FromString(color)
//             },
//         };

//         PointFeature pf = new(point)
//         {
//             ["Label"] = name,
//             Styles = [im]
//         };

//         MemoryLayer markerLayer = new()
//         {
//             Name = "Markers",
//             Features = [pf]
//         };

//         _markers.Add(markerLayer);
//     }
