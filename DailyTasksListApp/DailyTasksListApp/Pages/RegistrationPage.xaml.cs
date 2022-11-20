using DailyTasksListApp.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTasksListApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private async void btnRegistrClicked(object sender, EventArgs e)
        {
            User user = new User()
            {
                Name = nameEntry.Text,
                Surname = surnameEntry.Text,
                Email = emailEntry.Text,
                Password = passwordEntry.Text
            };
            if (!String.IsNullOrEmpty(user.Email) && !String.IsNullOrEmpty(user.Password))
            {
                if (passwordEntry.Text == password2Entry.Text)
                    App.Database.SaveUser(user);
                else
                    await DisplayAlert("Ошибка", "Пароли не совпадают", "ОК");
            }
            await this.Navigation.PopAsync();
        }
    }
}