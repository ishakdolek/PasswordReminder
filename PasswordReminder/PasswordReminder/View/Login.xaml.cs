using System;
using PasswordReminder.Controller;
using PasswordReminder.Extension;
using PasswordReminder.Model;
using PasswordReminder.View.Home;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace PasswordReminder.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private DataLayerManager _dataLayerManager;
        private Person _person;

        public Login()
        {
            InitializeComponent();
            _dataLayerManager= new DataLayerManager();
            _person= new Person();
        }

        private void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var result= _dataLayerManager.Login(new Person
            {
                Username =Username.Text,
                Password = Password.Text
            });
            if (result.IsSuccess)
            {
                var getPersonInformation = _dataLayerManager.GetPersonInformation(Username.Text.Trim());
                Application.Current.MainPage = new NavigationPage(new HomePage(getPersonInformation.Value));
            }
            else
            {
                DisplayAlert("Error", result.Message, "OK", "Cancel");
            }
       
        }

        private void OnSignUpButtonClicked(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Register(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage());
        }
        
        private void ReminderPassword(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ReminderPassword());
        }
    }

    
}
