using SQLite.Net;

namespace PasswordReminder.Helper
{
    public interface IConnectionHelper
    {
        SQLiteConnection GetConnection();
    }
}
