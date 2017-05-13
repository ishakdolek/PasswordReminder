using System;
using PasswordReminder.Controller;
using PasswordReminder.Extension;
using PasswordReminder.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PasswordReminder.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {


        public RegisterPage()
        {
            InitializeComponent();
        }

        private void Create(object sender, EventArgs e)
        {
            var dataLayerManager= new DataLayerManager();
        
            var result = dataLayerManager.SavePerson(new Person
            {
                Username =Username.Text.Trim(),
                Password =Password.Text.Trim(),
                Email = Email.Text.Trim(),
                ValidatedCode =ValidatedCode.Text.Trim()
            });

            if (result.IsSuccess)
            {
               DisplayAlert("Ok","Selam", "OK");
            }
            
        }
    }
}
