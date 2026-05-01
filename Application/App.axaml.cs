using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Data.Core.Plugins;
using System.Linq;
using Avalonia.Markup.Xaml;
using Restaurant.ViewModels;
using Restaurant.Views;
using Restaurant.Domain;


namespace Restaurant;

public partial class App : Application
{
    public override void Initialize()
    {
        Console.WriteLine("App Started");
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Avoid duplicate validations from both Avalonia and the CommunityToolkit. 
            // More info: https://docs.avaloniaui.net/docs/guides/development-guides/data-validation#manage-validationplugins
            DisableAvaloniaDataAnnotationValidation();
            desktop.ShutdownRequested += OnShutdownRequested;

            try
            {
                Console.WriteLine("Loading restaurant data...");
                StaticData.RestaurantDataService.LoadData();


                var recipes = StaticData.RestaurantDataService.GetRecipes();
                Console.WriteLine($"Recipes loaded: {recipes.Count}");

                if (recipes.Count > 0)
                {
                    Console.WriteLine($"First recipe: {recipes[0].Name}");
                }
                else
                {
                    Console.WriteLine("NO RECIPES FOUND");


                    Console.WriteLine("Restaurant data loaded successfully.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("CRASH IN LoadData():");
                Console.WriteLine(ex);
            }


            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }

    private void OnShutdownRequested(object? sender, ShutdownRequestedEventArgs e)
    {
        Console.WriteLine("Shutting down...");
    }

    private void DisableAvaloniaDataAnnotationValidation()
    {
        // Get an array of plugins to remove
        var dataValidationPluginsToRemove =
            BindingPlugins.DataValidators.OfType<DataAnnotationsValidationPlugin>().ToArray();

        // remove each entry found
        foreach (var plugin in dataValidationPluginsToRemove)
        {
            BindingPlugins.DataValidators.Remove(plugin);
        }
    }
}