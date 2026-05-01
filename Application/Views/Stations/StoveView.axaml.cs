using System;
using Avalonia.Controls;
using Restaurant.ViewModels;

namespace Restaurant.Views;

public partial class AnalyticsView : UserControl
{
    public AnalyticsView()
    {
        InitializeComponent();
        Loaded += OnLoading;
    }

    private void OnLoading(object? sender, EventArgs e)
    {
        DataContext = new AnalyticsViewModel();
    }
}