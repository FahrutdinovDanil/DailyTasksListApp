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
    public partial class AddMessagePage : ContentPage
    {
        public int idUser { get; set; }

        public AddMessagePage(int id, User user)
        {
            InitializeComponent();
            idUser = id;
            date_dp.MinimumDate = DateTime.Now;
            date_dp.MaximumDate = DateTime.Now.AddYears(1);
            stDateTime.IsVisible = false;
            this.BindingContext = this;
        }
        private async void SaveMessage(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            Message message = new Message();
            if (entName.Text != null)
            {
                message.Status = "Не сделано";
                message.Name = entName.Text;
                message.Discription = entDiscription.Text;
                message.UserName = user.Name;
                message.UserSurname = user.Surname;
                message.NewUserName = App.Database.GetUser(idUser).Name;
                message.NewUserSurname = App.Database.GetUser(idUser).Surname;
                message.IdUser = user.Id;
                message.IdNewUser = idUser;

                if (swDate.IsToggled == true)
                {
                    if (DateTime.Now < date_dp.Date)
                    {
                        message.IsDate = true;
                        message.DateTime = date_dp.Date.Add(time_tp.Time);
                        App.Database.SaveMessage(message);
                        await this.Navigation.PopAsync();
                    }
                    else if (DateTime.Now == date_dp.Date && DateTime.Now.TimeOfDay < time_tp.Time)
                    {
                        message.IsDate = true;
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
                    App.Database.SaveMessage(message);
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