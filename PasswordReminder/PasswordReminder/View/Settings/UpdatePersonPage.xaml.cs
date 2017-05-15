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
           //Password.Text = person.Password;
            //ValidatCode.Text = person.ValidatedCode;
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
            DisplayAlert("Success", "Tamam", "Ok");
        }
    }
    

    public class ConfirmPasswordBehavior : Behavior<Entry>
    {
        static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid", typeof(bool), typeof(ConfirmPasswordBehavior), false);
        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public static readonly BindableProperty CompareToEntryProperty = BindableProperty.Create("CompareToEntry", typeof(Entry), typeof(ConfirmPasswordBehavior), null);

        public Entry CompareToEntry
        {
            get { return (Entry)base.GetValue(CompareToEntryProperty); }
            set { base.SetValue(CompareToEntryProperty, value); }
        }
        public bool IsValid
        {
            get { return (bool)base.GetValue(IsValidProperty); }
            private set { base.SetValue(IsValidPropertyKey, value); }
        }
        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }
        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
        void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            var password = CompareToEntry.Text;
            var confirmPassword = e.NewTextValue;
            IsValid = password.Equals(confirmPassword);
            ((Entry)sender).TextColor = IsValid ? Color.Green : Color.Red;
        }
    }
}
