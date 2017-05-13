using SQLite.Net.Attributes;
using Xamarin.Forms;

namespace PasswordReminder.Model
{
    public class PersonSite
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string WebName { get; set; }
        public string Url { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        public  int PersonId { get; set; }
        public string LabelColor { get; set; }
        public string BackgroundColorSite { get; set; }
        public string Icon { get; set; }

    }
}
