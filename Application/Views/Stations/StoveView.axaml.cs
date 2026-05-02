using System;
using Avalonia.Controls;
using Restaurant.ViewModels;

namespace Restaurant.Views;

public partial class StoveView : UserControl
{
    public StoveView()
    {
        InitializeComponent();
        Loaded += OnLoading;
    }

    private void OnLoading(object? sender, EventArgs e)
    {
        DataContext = new StoveViewModel();
    }
}