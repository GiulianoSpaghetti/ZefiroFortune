using Avalonia;
using Avalonia.Browser;
using ReactiveUI.Avalonia;
using System.Runtime.Versioning;
using System.Threading.Tasks;

[assembly: SupportedOSPlatform("browser")]

namespace ZefiroFortune.Browser
{
    internal partial class Program
    {
        private static async Task Main(string[] args) => await BuildAvaloniaApp()
            .WithInterFont()
            .UseReactiveUI(_ => { })
            .StartBrowserAppAsync("out");

        public static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>();
    }
}
