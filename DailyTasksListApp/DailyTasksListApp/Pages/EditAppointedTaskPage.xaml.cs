using DailyTasksListApp.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTasksListApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EditAppointedTaskPage : ContentPage
    {
        public int idUser { get; set; }
        public EditAppointedTaskPage(Message message, int id)
        {
            InitializeComponent();
            idUser = id;
            if (message.IdUser == idUser)
            {
                if (message.IsDone == true)
                {
                    if (message.IsDate == false)
                    {
                        date_dp.IsVisible = false;
                        time_tp.IsVisible = false;
                    }
                    else
                    {
                        date_dp.IsEnabled = false;
                        time_tp.IsEnabled = false;
                    }
                    entDiscription.IsEnabled = false;
                    btnEdit.IsVisible = false;
                    date_dp.IsEnabled = false;
                    time_tp.IsEnabled = false;
                    lbAddDate.Text = "Дата до";
                    swDate.IsVisible = false;
                    entName.IsEnabled = false;
                    btnDone.IsVisible = false;
                }
                else
                {
                    if (message.IsDate == false)
                    {
                        date_dp.IsVisible = false;
                        time_tp.IsVisible = false;
                    }
                    else
                    {
                        date_dp.IsEnabled = false;
                        time_tp.IsEnabled = false;
                    }
                    entDiscription.IsEnabled = false;
                    btnEdit.IsVisible = false;
                    date_dp.IsEnabled = false;
                    time_tp.IsEnabled = false;
                    lbAddDate.Text = "Дата до";
                    swDate.IsVisible = false;
                    entName.IsEnabled = false;
                }
                
            }
            else
            {
                btnDone.IsVisible = false;
                time_tp.Time = message.DateTime.TimeOfDay;
                date_dp.MinimumDate = DateTime.Now;
                if (swDate.IsToggled == false)
                {
                    stDateTime.IsVisible = false;
                }
                else if (swDate.IsToggled == true)
                {
                    stDateTime.IsVisible = true;
                }
            }
            this.BindingContext = this;
        }
        private async void RemoveTask(object sender, EventArgs e)
        {
            var message = (Message)BindingContext;
            if (await DisplayAlert(" ", $"Вы хотите удалить {message.Name}?", "Удалить", "Отмена"))
            {
                App.Database.DeleteTask(message.Id);
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
            var message = (Message)BindingContext;
            if (!String.IsNullOrEmpty(message.Name))
            {
                if (swDate.IsToggled == true)
                {
                    message.IsDate = true;
                    if (DateTime.Now.ToShortDateString() != date_dp.Date.ToShortDateString())
                    {
                        message.DateTime = date_dp.Date.Add(time_tp.Time);
                        App.Database.SaveMessage(message);
                        await this.Navigation.PopAsync();
                    }
                    else if (DateTime.Now.ToShortDateString() == date_dp.Date.ToShortDateString() && DateTime.Now.TimeOfDay < time_tp.Time)
                    {
                        message.DateTime = date_dp.Date.Add(time_tp.Time);
                        App.Database.SaveMessage(message);
                        await this.Navigation.PopAsync();
                    }

                    else
                    {
                        await DisplayAlert("Ошибка", "Неверно указано время", "ОК");
                    }
                }

                else
                {
                    message.IsDate = false;
                    App.Database.SaveMessage(message);
                    await this.Navigation.PopAsync();
                }
            }
        }
        private async void EditTask(object sender, EventArgs e)
        {
            var message = (Message)BindingContext;

            if (!String.IsNullOrEmpty(message.Name))
            {
                message.IsDone = true;
                message.Status = "Сделано";
                App.Database.SaveMessage(message);
            }
            await this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}