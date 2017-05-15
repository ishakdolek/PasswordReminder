using System.Collections.Generic;
using System.Linq;
using PasswordReminder.Controller;
using PasswordReminder.Model;
using PasswordReminder.View.Settings;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PasswordReminder.View.Home
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomePage : ContentPage
    {
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

        private Color _color;
        List<Color> itemColors= new List<Color>(); 
        DataLayerManager dataLayerManager;
        private Person _person;

        public HomePage(Person person)
        {
            _person = person;
            InitializeComponent();
            Title = "Password Reminder";
            Icon = "appIcon.png";

            ToolbarItems.Add(new ToolbarItem
            {
                Text =person.Username,
                Order = ToolbarItemOrder.Primary,
         
            });
            ToolbarItems.Add(new ToolbarItem
            {
                Icon = "plus.png",
                Order = ToolbarItemOrder.Primary,
                Command = new Command(AddNewWebsite),
            });

            ToolbarItems.Add(new ToolbarItem
            {
                Text = "Settings",
                Order = ToolbarItemOrder.Secondary,
                Command = new Command(UpdateProfilInformation)
            });

            dataLayerManager = new DataLayerManager();
            var listPersonSite = dataLayerManager.GetAllPersonSites().ToList();
            ListPersonSiteInformation.BindingContext = listPersonSite;
            //foreach (var item in listPersonSite)
            //{
            //    ListPersonSiteInformation.BackgroundColor = _nameToColor.FirstOrDefault(x => x.Key == item.BackgroundColorSite).Value;
            //}
        }

        private  void UpdateProfilInformation(object obj)
        {
            Navigation.PushAsync(new UpdatePersonPage(_person));
        }

        private void AddNewWebsite(object obj)
        {
             var personResult = dataLayerManager.GetPersonInformation(_person.Username);
            if (personResult.IsSuccess)
            {
                Navigation.PushAsync(new DetailPage(personResult.Value));
            }
        }

        private void ListPersonSiteInformation_OnFlowItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (PersonSite)e.Item;
            Navigation.PushAsync(new HomePageDetail(item));
        }
    }
}
