using PasswordReminder.Droid.Helper;
using PasswordReminder.Helper;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using Environment = System.Environment;

[assembly: Xamarin.Forms.Dependency(typeof(DroidConnectionHelper))]
namespace PasswordReminder.Droid.Helper
{
   public class DroidConnectionHelper: IConnectionHelper
    {
        public SQLiteConnection GetConnection()
        {
            var documentPath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = System.IO.Path.Combine(documentPath, App.DbName);
            var platform = new SQLitePlatformAndroid();
            var connection = new SQLiteConnection(platform, path);
            return connection;
        }
    }
}