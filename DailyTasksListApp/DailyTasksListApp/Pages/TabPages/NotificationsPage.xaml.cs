using DailyTasksListApp.SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTasksListApp.Pages.TabPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NotificationsPage : ContentPage
    {
        public User User { get; set; }
        public int idUser { get; set; }
        public Request request { get; set; }
        public NotificationsPage(int IdUser)
        {
            InitializeComponent();
            Title = "Уведомления";
            idUser = IdUser;
            User = App.Database.GetUserId(IdUser);
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            messagesList.ItemsSource = App.Database.GetRequests().Where(a => a.IdNewUser == idUser && a.IsReceived == false && a.IsNotReceived == false);
            base.OnAppearing();
        }
        private async void messagesList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Request selectedRequest = (Request)e.SelectedItem;
            if (await DisplayAlert("Уведомление", $"Пользователь {selectedRequest.NameNewUser} хочет добавить вас в друзья. Он оставил вам сообщение: '{selectedRequest.Message}'. Вы хотите принять запрос от {selectedRequest.NameNewUser}?", "Принять", "Отклонить"))
            {
                if (!String.IsNullOrEmpty(selectedRequest.Message))
                {
                    selectedRequest.IsReceived = true;

                    App.Database.SaveRequest(selectedRequest);
                }
                await this.Navigation.PopAsync();
                Friend freinds = new Friend()
                {
                    IdUser = selectedRequest.IdUser,
                    IdNewUser = selectedRequest.IdNewUser
                };
                App.Database.SaveFriend(freinds);
            }
            else
            {
                if (!String.IsNullOrEmpty(selectedRequest.Message))
                {
                    selectedRequest.IsNotReceived = true;
                    App.Database.SaveRequest(selectedRequest);
                }
                await this.Navigation.PopAsync();
            }
        }
    }
}