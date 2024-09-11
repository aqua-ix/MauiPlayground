using Android.App;
using Android.Content.PM;
using Android.OS;

namespace MauiPlayground
{
    [Activity(Name = "com.companyname.mauiplayground.MainActivity",
        Theme = "@style/Maui.SplashTheme",
        Exported = true,
        LaunchMode = LaunchMode.SingleTop,
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode |
                               ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
    }
}