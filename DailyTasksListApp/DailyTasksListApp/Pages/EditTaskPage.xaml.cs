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
            time_tp.Time = task.DateTime.TimeOfDay;
            date_dp.MinimumDate = DateTime.Now;
            if (swDate.IsToggled == false)
            {
                stDateTime.IsVisible = false;
            }
            else if (swDate.IsToggled == true)
            {
                stDateTime.IsVisible = true;
            }
            this.BindingContext = this;
        }
        private async void RemoveTask(object sender, EventArgs e)
        {
            var task = (Task)BindingContext;
            if (await DisplayAlert(" ", $"Вы хотите удалить {task.Name}?", "Удалить", "Отмена"))
            {
                //task.DateTime = date_dp.Date.Add(time_tp.Time);
                App.Database.DeleteTask(task.Id);
                //await Navigation.PushAsync(new PlannedTasksPage(task.IdUser));
                await this.Navigation.PopAsync();
            }
        }

        private void swDate_Toggled(object sender, ToggledEventArgs e)
        {
            if (swDate.IsToggled == false)
            {
                stDateTime.IsVisible = false;
            }
            else if (swDate.IsToggled == true)
            {
                stDateTime.IsVisible = true;
            }
        }

        private async void SaveTask(object sender, EventArgs e)
        {
            var task = (Task)BindingContext;
            if (!String.IsNullOrEmpty(task.Name))
            {
                if (swDate.IsToggled == true)
                {
                    task.IsDate = true;
                    if (DateTime.Now.ToShortDateString() != date_dp.Date.ToShortDateString())
                    {
                        task.DateTime = date_dp.Date.Add(time_tp.Time);
                        App.Database.SaveTask(task);
                        await this.Navigation.PopAsync();
                    }
                    else if (DateTime.Now.ToShortDateString() == date_dp.Date.ToShortDateString() && DateTime.Now.TimeOfDay < time_tp.Time)
                    {
                        task.DateTime = date_dp.Date.Add(time_tp.Time);
                        App.Database.SaveTask(task);
                        await this.Navigation.PopAsync();
                    }

                    else
                    {
                        await DisplayAlert("Ошибка", "Неверно указано время", "ОК");
                    }
                }

                else
                {
                    task.IsDate = false;
                    App.Database.SaveTask(task);
                    await this.Navigation.PopAsync();
                }
            }
        }
        private async void EditTask(object sender, EventArgs e)
        {
            var task = (Task)BindingContext;

            if (!String.IsNullOrEmpty(task.Name))
            {
                task.IsDone = true;
                task.IsDoneImage = "done.png";
                App.Database.SaveTask(task);
            }
            //await DisplayAlert(" ", $"Вы хотите изменить {task.Name}?", "Изменить", "Отмена");
            await this.Navigation.PopAsync();
        }

            private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}