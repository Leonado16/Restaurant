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

    // [ObservableProperty]
    // public Airport? _selectedAirportArrival;

    // public AirportInfoViewModel() : base()
    // {
    //     if (StaticData.UserPreferences.SelectedAirportArrival is not null)
    //     {
    //         SelectedAirportArrival = StaticData.FlightDataService.GetAirport(StaticData.UserPreferences.SelectedAirportArrival.IataCode);
    //     }
    //     Scheduled = StaticData.UserPreferences.Scheduled;
    //     Landed = StaticData.UserPreferences.Landed;
    //     DrawFlights();
    // }

    // private void DrawFlights()
    // {
    //     OrderCard.Clear();
    //     foreach (Flight flight in StaticData.FlightDataService.GetFlights())
    //     {
    //         if (Landed && flight.Status != "Landed") continue;
    //         if (Scheduled && flight.Status != "Scheduled") continue;
    //         if (SelectedAirportArrival is not null && flight.ArrivalAirport != SelectedAirportArrival.IataCode) continue;
    //         if (SelectedAirport is not null && flight.DepartureAirport != SelectedAirport.IataCode) continue;

    //         FlightCards.Add(new FlightCardViewModel(flight));
    
    // }

}