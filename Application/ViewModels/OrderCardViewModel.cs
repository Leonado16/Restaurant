using System;
using CommunityToolkit.Mvvm.ComponentModel;
using Restaurant.Domain;
using Restaurant.Models;

namespace Restaurant.ViewModels;

public partial class OrderCardViewModel : ViewModelBase
{    
    [ObservableProperty]
    private string? _recipeFollowed;

    // add steps etc.

    [ObservableProperty]
    private int _currentStepIndex;

    [ObservableProperty]
    private double _orderProgress;


    public OrderCardViewModel(Order order)
    {
        RecipeFollowed = order.RecipeFollowed.Name; 
        CurrentStepIndex = order.CurrentStepIndex;
        OrderProgress = order.OrderProgress;
    }
}

//     public FlightCardViewModel(Flight flight)
//     {
//         Airport arrivalPlace = StaticData.FlightDataService.GetAirport(flight.ArrivalAirport) ?? throw new Exception($"No Airport with IataCode {flight.ArrivalAirport}");
//         Airport departurePlace = StaticData.FlightDataService.GetAirport(flight.DepartureAirport) ?? throw new Exception($"No Airport with IataCode {flight.DepartureAirport}");

//         DepatureAirport = flight.DepartureAirport + " " + departurePlace.Name;
//         ArrivalAirport = flight.ArrivalAirport + " " + arrivalPlace.Name;
//         AircraftType = flight.AircraftType;
//         Airline = flight.AirlineName + " " + flight.AirlineCode;
//         FlightNumber = flight.FlightNumber;
//         ArrivalTime = flight.ScheduledArrival.ToString("HH:mm");
//         DepatureTime = flight.ScheduledDeparture.ToString("HH:mm");
//     }
// }
