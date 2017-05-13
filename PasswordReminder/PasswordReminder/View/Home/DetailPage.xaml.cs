using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordReminder.Controller;
using PasswordReminder.Extension;
using PasswordReminder.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PasswordReminder.View.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailPage : ContentPage
    {
        private string _colorName;
        private Person _person;
        public DetailPage(Person person)
        {
            InitializeComponent();
            AddColorToPicker();
            _person = person;
        }
        readonly Dictionary<string, Color> _nameToColor = new Dictionary<string, Color>
        {
            { "Default", Color.Default },                  { "Amber", Color.FromHex("#FFC107") },
            { "Black", Color.FromHex("#212121") },         { "Blue", Color.FromHex("#2196F3") },
            { "Blue Grey", Color.FromHex("#607D8B") },     { "Brown", Color.FromHex("#795548") },
            { "Cyan", Color.FromHex("#00BCD4") },          { "Dark Orange", Color.FromHex("#FF5722") },
            { "Dark Purple", Color.FromHex("#673AB7") },   { "Green", Color.FromHex("#4CAF50") },
            { "Grey", Color.FromHex("#9E9E9E") },          { "Indigo", Color.FromHex("#3F51B5") },
            { "Light Blue", Color.FromHex("#02A8F3") },    { "Light Green", Color.FromHex("#8AC249") },
            { "Lime", Color.FromHex("#CDDC39") },          { "Orange", Color.FromHex("#FF9800") },
            { "Pink", Color.FromHex("#E91E63") },          { "Purple", Color.FromHex("#94499D") },
            { "Red", Color.FromHex("#D32F2F") },           { "Teal", Color.FromHex("#009587") },
            { "White", Color.FromHex("#FFFFFF") },         { "Yellow", Color.FromHex("#FFEB3B") },
        };

        private void AddColorToPicker()
        {
            ColorPicker.Title = "Select Background Color";
            foreach (var item in _nameToColor.Keys)
            {
                ColorPicker.Items.Add(item);
            }
            ColorPicker.SelectedIndexChanged += (sender, args) =>
            {
                if (ColorPicker.SelectedIndex == -1)
                {
                    _colorName = ColorPicker.Items[0];
                }
                else
                {
                    _colorName = ColorPicker.Items[ColorPicker.SelectedIndex];
               
                }
            };
        }

        private async Task Button_OnClicked(object sender, EventArgs e)
        {
            var datamanager = new DataLayerManager();
            var personResult= datamanager.GetPersonInformation(_person.Username);
            if (personResult.IsSuccess)
            {
            var result = datamanager.SavePersonSite(new PersonSite
            {
                PersonId = personResult.Value.Id,
                Email = Email.Text.Trim(),
                Password = Password.Text.Trim(),
                Phone = Phone.Text.Trim(),
                Url = Url.Text.Trim(),
                Username = Username.Text.Trim(),
                WebName = WebName.Text.Trim(),
                BackgroundColorSite = ColorPicker.Items[ColorPicker.SelectedIndex]
            });
            
            if (result.IsSuccess)
            {
                var answer = await DisplayAlert("Success", "WebSite Kayıt Edildi", "Tamam", "Cancel");
                if (answer)
                {
                    Application.Current.MainPage = new NavigationPage(new HomePage(_person));
                }
            }
           }
        }
    }
}
