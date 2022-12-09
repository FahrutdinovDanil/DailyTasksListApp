using DailyTasksListApp.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTasksListApp.Pages.TabPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersPage : ContentPage
    {
        public int idUser { get; set; }
        public UsersPage(int id)
        {
            InitializeComponent();
            idUser = id;
            Title = "Пользователи";
            BindingContext = this;
        }
        protected override void OnAppearing()
        {
            usersList.ItemsSource = App.Database.GetUsers().Where(a => a.Id != idUser);
            base.OnAppearing();
        }
        private async void usersList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            User selectedUser = (User)e.SelectedItem;
            SendRequestPage requestPage = new SendRequestPage(idUser, selectedUser.Id);
            requestPage.BindingContext = selectedUser;
            await Navigation.PushAsync(requestPage);
        }
        public UsersPage()
        {
            InitializeComponent();
        }

        public void Filter()
        {
            var filterUser = App.Database.GetUsers().Where(a => a.Id != idUser);
            if (entSearch.Text != "")
            {
                filterUser = App.Database.GetUsers().Where(z => (z.Id != idUser && (z.Name.Contains(entSearch.Text) || z.Surname.Contains(entSearch.Text))));
            }
            usersList.ItemsSource = filterUser;
        }

        private void entSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            Filter();
        }
    }
}