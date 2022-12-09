using DailyTasksListApp.SQLite;
using System;
using DailyTasksListApp.Pages;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTasksListApp.Pages.AppointedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointedMeTasksPage : ContentPage
    {
        public int idUser { get; set; }
        public AppointedMeTasksPage(int id)
        {
            InitializeComponent();
            idUser = id;
            Title = "Назначенные мне";
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            tasksList.ItemsSource = App.Database.GetMessagesId(idUser);
            base.OnAppearing();
        }
        private async void appointedtasksList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Message selectedProject = (Message)e.SelectedItem;
            EditAppointedTaskPage projectPage = new EditAppointedTaskPage(selectedProject, idUser);
            projectPage.BindingContext = selectedProject;
            await Navigation.PushAsync(projectPage);
        }
    }
}