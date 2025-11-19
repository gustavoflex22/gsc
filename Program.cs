using Avalonia;

namespace FuturoDoTrabalho
{
    internal static class Program
    {
        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();

        public static void Main(string[] args)
            => BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
    }
}
