using DailyTasksListApp.Pages;
using DailyTasksListApp.Pages.TabPages;
using DailyTasksListApp.SQLite;
using DailyTasksListApp.ViewModels;
using DailyTasksListApp.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace DailyTasksListApp
{
    public partial class AppShell : Shell
    {
        public User Iuser { get; set; }
        public AppShell(User user)
        {
            InitializeComponent();
            Iuser = user;
            this.BindingContext = this;
        }

        private async void appointed_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AppointedTasksPage(/*Iuser.Id*/));
            Current.FlyoutIsPresented = false;
        }
        private async void important_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ImportantTasksPage(/*Iuser.Id*/));
            Current.FlyoutIsPresented = false;
        }
        private void planned_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PlannedTasksPage(/*Iuser*/));
            Current.FlyoutIsPresented = false;
        }
        private void tasks_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TasksPage(Iuser.Id));
            Current.FlyoutIsPresented = false;
        }
        private void products_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new ProductsPage(/*Iuser.Id*/));
            Current.FlyoutIsPresented = false;
        }

        private void users_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new UsersTabbedPage(Iuser.Id));
            Current.FlyoutIsPresented = false;
        }
        private void exit_Clicked(object sender, EventArgs e)
        {
            Application.Current.MainPage = new Main();
        }
    }
}
