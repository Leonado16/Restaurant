using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using Restaurant.Domain;
using Restaurant.Models;
using System;

namespace Restaurant.ViewModels;

public partial class AirportSelectionViewModel : ViewModelBase
{
    // public ObservableCollection<Airport> Airports { get; set; }

    // [ObservableProperty]
    // public Airport? _selectedAirport;

    // public AirportSelectionViewModel()
    // {
    //     Airports = new ObservableCollection<Airport>(StaticData.FlightDataService.GetAirports());
    //     if (StaticData.UserPreferences.SelectedAirport is not null)
    //     {
    //         SelectedAirport = StaticData.FlightDataService.GetAirport(StaticData.UserPreferences.SelectedAirport.IataCode);
    //     }
    // }
}