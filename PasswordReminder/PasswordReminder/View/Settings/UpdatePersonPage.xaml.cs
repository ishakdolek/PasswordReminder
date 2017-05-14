using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordReminder.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PasswordReminder.View.Settings
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatePersonPage : ContentPage
    {
        private Person _person;
        public UpdatePersonPage(Person person)
        {
            _person = person;
            InitializeComponent();
            Email.Text = person.Email;
            Username.Text = person.Username;
            Password.Text = person.Password;
            ValidatCode.Text = person.ValidatedCode;
        }

        private void UpdateUsernameAndEmail(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ChangePassword(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ChangeValidateCode(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
