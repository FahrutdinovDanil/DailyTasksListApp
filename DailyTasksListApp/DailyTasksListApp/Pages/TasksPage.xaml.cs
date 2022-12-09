using DailyTasksListApp.Pages;
using DailyTasksListApp.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTasksListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TasksPage : ContentPage
    {
        public int idUser { get; set; }
        public TasksPage(int id)
        {
            InitializeComponent();
            idUser = id;
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            tasksList.ItemsSource = App.Database.GetTasksId(idUser).Where(a => a.IsImportant == false && a.IsDate == false);
            base.OnAppearing();
        }

        private async void AddTask(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddTaskPage(idUser));
        }

        private async void tasksList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Task selectedProject = (Task)e.SelectedItem;
            EditTaskPage projectPage = new EditTaskPage(selectedProject);
            projectPage.BindingContext = selectedProject;
            await Navigation.PushAsync(projectPage);
        }
    }
}