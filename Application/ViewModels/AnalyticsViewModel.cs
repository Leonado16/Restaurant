namespace Restaurant.ViewModels;

using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;
using System.Linq;
using Restaurant.Models;
using Restaurant.Domain;
using Restaurant.Persistence;

public partial class AnalyticsViewModel
{
    // public ObservableCollection<RouteTraffic> BusiestRoutes { get; } = [];
    // public ObservableCollection<AirlineTraffic> TopAirlines { get; } = [];
    // public ObservableCollection<AirportTraffic> TopAirports { get; } = [];

    // public AnalyticsViewModel()
    // {
    //     var flights = StaticData.FlightDataService.GetFlights();

    //     List<RouteTraffic> busiestRoutes = flights.Select(flight => new
    //     {
    //         DepartureAirport = flight.DepartureAirport,
    //         ArrivalAirport = flight.ArrivalAirport,
    //     })
    //     .GroupBy(flight => (flight.DepartureAirport, flight.ArrivalAirport))
    //     .Select(grp => new RouteTraffic
    //     {
    //         DepartureAirport = grp.Key.DepartureAirport,
    //         ArrivalAirport = grp.Key.ArrivalAirport,
    //         Count = grp.Count()
    //     })
    //     .OrderByDescending(route => route.Count)
    //     .ToList();

    //     BusiestRoutes.Clear();
    //     foreach (RouteTraffic busyRoute in busiestRoutes)
    //     {
    //         BusiestRoutes.Add(busyRoute);
    //     }

    //     var uniqueAirlineCodes = flights.Select(flight => new
    //     {
    //         AirlineCode = flight.AirlineCode,
    //         AirlineName = flight.AirlineName,
    //     }).Distinct();

    //     List<AirlineTraffic> topAirlines = flights.Select(flight => new
    //     {
    //         AirlineCode = flight.AirlineCode,
    //     })
    //     .GroupBy(flight => flight.AirlineCode)
    //     .Select(grp => new
    //     {
    //         AirlineCode = grp.Key,
    //         Count = grp.Count()
    //     })
    //     .Join(uniqueAirlineCodes, route => route.AirlineCode, flights => flights.AirlineCode, (route, flight) => new AirlineTraffic
    //     {
    //         AirlineCode = route.AirlineCode,
    //         AirlineName = flight.AirlineName,
    //         FlightCount = route.Count
    //     })
    //     .OrderByDescending(route => route.FlightCount)
    //     .ToList();

    //     TopAirlines.Clear();
    //     foreach (AirlineTraffic airlineTraffic in topAirlines)
    //     {
    //         TopAirlines.Add(airlineTraffic);
    //     }

    //     var departureCounts = flights.Select(flight => new
    //     {
    //         DepartureAirport = flight.DepartureAirport,
    //     })
    //     .GroupBy(flight => flight.DepartureAirport)
    //     .Select(grp => new
    //     {
    //         DepartureAirport = grp.Key,
    //         Count = grp.Count()
    //     })
    //     .ToList();

    //     var arrivalCounts = flights.Select(flight => new
    //     {
    //         ArrivalAirport = flight.ArrivalAirport,
    //     })
    //     .GroupBy(flight => flight.ArrivalAirport)
    //     .Select(grp => new
    //     {
    //         ArrivalAirport = grp.Key,
    //         Count = grp.Count()
    //     })
    //     .ToList();

    //     List<AirportTraffic> topAirports = departureCounts.Join(arrivalCounts, departureData => departureData.DepartureAirport, arrivalData => arrivalData.ArrivalAirport, (departureData, arrivalData) => new AirportTraffic
    //     {
    //         AirportCode = departureData.DepartureAirport,
    //         FlightCount = departureData.Count + arrivalData.Count,
    //         DepartureCount = departureData.Count,
    //         ArrivalCount = arrivalData.Count
    //     })
    //     .OrderByDescending(airport => airport.FlightCount)
    //     .ToList();

    //     TopAirports.Clear();
    //     foreach (AirportTraffic airportTraffic in topAirports)
    //     {
    //         TopAirports.Add(airportTraffic);
    //     }
    // }

    // [RelayCommand]
    // public void ExportFlightData()
    // {
    //     StaticData.FlightDataService.ExportData();
    // }

    // [RelayCommand]
    // public void ExportAnalyticsOutput()
    // {
    //     var analyticsObject = new Analytics
    //     {
    //         BusiestRoutes = BusiestRoutes,
    //         TopAirlines = TopAirlines,
    //         TopAirports = TopAirports,
    //     };

    //     StaticData.Persistence.Save<Analytics>(analyticsObject, "export_analytics.json");
    // }
}