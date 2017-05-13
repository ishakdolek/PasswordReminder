using PasswordReminder.Droid.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
[assembly: ExportRenderer(typeof(Entry), typeof(MyEntryRenderer))]
namespace PasswordReminder.Droid.Renderer
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(global::Android.Graphics.Color.White);
        }
    }
}