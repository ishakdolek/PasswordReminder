using System;
using System.Threading.Tasks;
using PasswordReminder.Controller;
using PasswordReminder.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PasswordReminder.View.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePageDetail : ContentPage
    {
        private readonly PersonSite _personSite;

        public HomePageDetail(PersonSite personSite)
        {
            _personSite = personSite;
            InitializeComponent();
            Title = _personSite.Url;
            Email.Text = _personSite.Email;
            UrlEntry.Text = _personSite.Url;
            Username.Text = _personSite.Username;
            Phone.Text = _personSite.Phone;
            Password.Text = _personSite.Password;
            //Password.Text = _personSite.BackgroundColorSite;
        }

        private void ShowMyPasswordWithId(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PasswordReminderPage(_personSite));
        }
        private async Task DeleteSite(object sender, EventArgs e)
        {
            var dataLayerManager = new DataLayerManager();
            var answer = await DisplayAlert("Silinsin mi", "Silmek İstediğinizden Emin misiniz?", "Tamam", "Cancel");
            if (answer)
            {
                var result = dataLayerManager.Delete(_personSite.Id);
                if (result.IsSuccess)
                {
                    await DisplayAlert("Başarılı", "Veri Silindi", "OK", "CANCEL");
                }
            }

        }
    }
}
