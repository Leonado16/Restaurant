using Avalonia;
using Avalonia.Controls;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Avalonia.Input;
using Restaurant.Domain;
using Restaurant.ViewModels;
using System.Diagnostics;
// using MyAvaloniaApp;
// using MyAvaloniaApp.ViewModels;
// using MyAvaloniaApp.Models;
// using MyAvaloniaApp.Views;
// using MyAvaloniaApp.Domain;
using Xunit;

namespace TestableApp.Headless.XUnit;

public class UnitTest1
{
    [AvaloniaFact]
    public void Avalonia_TestWorking()
    {
        // Setup controls:
        var textBox = new TextBox();
        var window = new Window { Content = textBox };

        // Open window:
        window.Show();

        // Focus text box:
        textBox.Focus();

        // Simulate text input:
        window.KeyTextInput("Hello World");

        // Assert:
        Assert.Equal("Hello World", textBox.Text);
    }
}
