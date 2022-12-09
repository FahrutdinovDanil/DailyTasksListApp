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
    public partial class PlannedTasksPage : ContentPage
    {
        public int idUser { get; set; }
        public PlannedTasksPage(int id)
        {
            InitializeComponent();
            idUser = id;
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            List<Task> plannedTasks = App.Database.GetTasksId(idUser).Where(a => a.IsDate == true && a.IsImportant == false).ToList();
            foreach (Task task in plannedTasks)
            {
                if (task.IsDone == false)
                {
                    DateTime today = DateTime.Now;
                    DateTime next = task.DateTime;

                    if (next < today)
                        next = next.AddYears(1);

                    int numDays = (next - today).Days;
                    int numHours = (next - today).Hours;
                    int numMinutes = (next - today).Minutes;
                    if (numDays == 0)
                    {
                        task.RemainedDateTime = $"{numHours} час. {numMinutes} мин.";
                    }
                    else if (numDays == 0 && numHours == 0)
                    {
                        task.RemainedDateTime = $"{numMinutes} мин.";
                    }
                    else if (numHours == 0 && numDays == 0 && numMinutes == 0)
                    {
                        task.RemainedDateTime = $"Истекло";
                    }
                    else if (numHours == 0 && numMinutes == 0)
                    {
                        task.RemainedDateTime = $"{numDays} дн.";
                    }
                    else if (numMinutes == 0 && numDays == 0)
                    {
                        task.RemainedDateTime = $"{numHours} час.";
                    }
                    else
                    {
                        task.RemainedDateTime = $"{numDays} дн. {numHours} час. {numMinutes} мин.";
                    }
                    
                }
                else
                {
                    task.RemainedDateTime = $"Истекло";
                }
            }
            tasksList.ItemsSource = plannedTasks;
            base.OnAppearing();
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