using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using DailyTasksListApp.SQLite;

namespace DailyTasksListApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditTaskPage : ContentPage
    {
        public EditTaskPage(Task task)
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private async void RemoveTask(object sender, EventArgs e)
        {
            var task = (Task)BindingContext;
            if (await DisplayAlert(" ", $"Вы хотите удалить {task.Name}?", "Удалить", "Отмена"))
            {
                App.Database.DeleteTask(task.Id);
                await Navigation.PushAsync(new TasksPage(task.IdUser));
            }
        }

        private async void SaveTask(object sender, EventArgs e)
        {
            var task = (Task)BindingContext;
            if (await DisplayAlert(" ", $"Вы хотите изменить {task.Name}?", "Изменить", "Отмена"))
            {
                if (!String.IsNullOrEmpty(task.Name))
                {
                    App.Database.SaveTask(task);
                }
                await this.Navigation.PopAsync();
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}