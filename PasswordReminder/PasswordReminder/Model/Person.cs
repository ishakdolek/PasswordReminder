using SQLite.Net.Attributes;

namespace PasswordReminder.Model
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string ValidatedCode { get; set; }
        public string Email { get; set; }
        public bool  RememberMe { get; set; }
    }
}
