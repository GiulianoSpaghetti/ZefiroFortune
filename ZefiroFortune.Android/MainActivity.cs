using Android.App;
using Android.Content.PM;
using Avalonia.Android;

namespace ZefiroFortune.Android
{
    [Activity(
        Label = "Il fortune di numerone zefiro",
        Theme = "@style/MyTheme.NoActionBar",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]
    public class MainActivity : AvaloniaMainActivity
    {
    }
}
