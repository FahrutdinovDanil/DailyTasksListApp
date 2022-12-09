using DailyTasksListApp.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTasksListApp.Pages.AppointedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SendedTasksPage : ContentPage
    {
        public int idUser { get; set; }
        public SendedTasksPage(int id)
        {
            InitializeComponent();
            idUser = id;
            Title = "Назначенные мной";
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            tasksList.ItemsSource = App.Database.GetMessages().Where(a => a.IdNewUser == idUser);
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