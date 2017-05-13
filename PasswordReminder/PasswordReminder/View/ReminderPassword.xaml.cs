using System;
using PasswordReminder.Controller;
using PasswordReminder.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PasswordReminder.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReminderPassword : ContentPage
    {
        private DataLayerManager _dataLayerManager;

        public ReminderPassword()
        {
            InitializeComponent();
        }

        private void SendEmail(object sender, EventArgs e)
        {
            _dataLayerManager = new DataLayerManager();
            var result = _dataLayerManager.GetDataWithFieldValue(Email.Text.Trim());
            if (result.IsSuccess)
            {
                SendMail(result.Value);
            }
            else
            {
                DisplayAlert("Error", "Email mevcut değil", "Ok", "Cancel");
            }

        }

        protected virtual void SendMail(Person value)
        {

            //var emailTask = EmailMessenger;
            //if (emailTask.CanSendEmail)
            //    emailTask.SendEmail(value.Email,"Forgot Password","Your Username:"+value.Username + " Your Password :"+value.Password);
        }
    }
}
