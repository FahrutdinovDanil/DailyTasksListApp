using DailyTasksListApp.SQLite;
using DailyTasksListApp.ViewModels;
using DailyTasksListApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DailyTasksListApp
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public User Iuser { get; set; }
        public AppShell(User user)
        {
            InitializeComponent();
            Iuser = user;
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            this.BindingContext = this;
        }

        private async void OnMenuItemClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//LoginPage");
        }
    }
}
