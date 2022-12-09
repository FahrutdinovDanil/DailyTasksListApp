using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DailyTasksListApp.SQLite;
using Xamarin.Forms;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace DailyTasksListApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTaskPage : ContentPage
    {
        public int idUser { get; set; }
        public AddTaskPage(int id)
        {
            InitializeComponent();
            idUser = id;
            date_dp.MinimumDate = DateTime.Now;
            date_dp.MaximumDate = DateTime.Now.AddYears(1);
            stDateTime.IsVisible = false;
            this.BindingContext = this;
        }

        private async void SaveTask(object sender, EventArgs e)
        {
            Task task = new Task();
            if (entName.Text != null)
            { 
                task.Name = entName.Text;
                task.Discription = entDiscription.Text;
                task.IdUser = idUser;
                task.IsImportant = cbIsImportant.IsChecked;
                if (cbIsImportant.IsChecked == false)
                    task.IsDoneImage = "not.png";
                else
                    task.IsDoneImage = "star.png";
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
            else
            {
                await DisplayAlert("Ошибка", "Неверные данные", "ОК");
            }

        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
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
    }
}