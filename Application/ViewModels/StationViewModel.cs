using System.Collections.Generic;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Restaurant.Domain;
using Restaurant.Models;


namespace Restaurant.ViewModels;

public partial class StationViewModel //: AirportSelectionViewModel
{
    // [ObservableProperty]
    // private Map _map = new();

    // private readonly List<MemoryLayer> _markers = [];

    // public GeneralViewModel() : base()
    // {
    //     Map.Layers.Add(OpenStreetMap.CreateTileLayer());
    //     Map.Navigator.CenterOn(MPConvert(12.6560, 55.6179));

    //     DrawMarkers();

    //     Map.Info += OnMarkerClicked;
    // }

    // private void DrawMarkers()
    // {
    //     if (Map.Layers.Count > 1)
    //     {
    //         List<ILayer> layers = [.. Map.Layers];
    //         _markers.Clear();
    //         Map.Layers.Clear();
    //         Map.Layers.Add(layers[0]);
    //     }

    //     foreach (Airport airport in Airports)
    //     {
    //         string color = "#588098";
    //         if (airport == SelectedAirport) color = "#78d375";
    //         if (SelectedAirport is not null)
    //         {
    //             List<Flight> flights = StaticData.FlightDataService.GetFlights(SelectedAirport);
    //             foreach (Flight flight in flights)
    //             {
    //                 if (airport.IataCode == flight.ArrivalAirport)
    //                 {
    //                     color = "#d37575";
    //                 }
    //             }
    //         }

    //         AddPin(MPConvert(airport.Longitude, airport.Latitude), airport.IataCode, color);
    //     }

    //     Map.Layers.Add(_markers);
    // }


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
}