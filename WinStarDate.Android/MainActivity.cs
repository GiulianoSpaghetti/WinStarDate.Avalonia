using Android.App;
using Android.Content.PM;
using Avalonia;
using Avalonia.Android;

namespace WinStarDate.Android;

[Activity(Label = "WinStarDate.Android", Theme = "@style/MyTheme.NoActionBar", Icon = "@drawable/icon", LaunchMode = LaunchMode.SingleTop, ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize | ConfigChanges.UiMode)]

public class MainActivity : AvaloniaMainActivity<App>
{
    protected override AppBuilder CustomizeAppBuilder(AppBuilder builder)
    {
       return base.CustomizeAppBuilder(builder);
    }
}
