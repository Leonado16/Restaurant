using Avalonia;
using Avalonia.Headless;
using Restaurant;

[assembly: AvaloniaTestApplication(typeof(TestAppBuilder))]
public class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp() => AppBuilder.Configure<App>()
        .UseHeadless(new AvaloniaHeadlessPlatformOptions());
}