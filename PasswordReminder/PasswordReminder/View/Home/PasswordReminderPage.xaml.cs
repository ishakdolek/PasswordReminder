using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordReminder.Controller;
using PasswordReminder.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PasswordReminder.View.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasswordReminderPage : ContentPage
    {
        private readonly PersonSite _personSite;
        private DataLayerManager _dataLayerManager;
        public PasswordReminderPage(PersonSite personSite)
        {
            _personSite = personSite;
            InitializeComponent();
        }

        private void ShowPassword(object sender, EventArgs e)
        {
            _dataLayerManager = new DataLayerManager();
            var resultPassword = _dataLayerManager.GetPersonById(_personSite.PersonId);
            if (resultPassword.IsSuccess)
            {
                if (ValidateCode.Text.Trim()==resultPassword.Value.ValidatedCode)
                {
                    DisplayAlert("Şifre", _personSite.Password, "Ok");
                }
                else
                {
                    DisplayAlert("Şifre", "Validate Code Error!", "Ok");
                }
            }


        }
    }
}
