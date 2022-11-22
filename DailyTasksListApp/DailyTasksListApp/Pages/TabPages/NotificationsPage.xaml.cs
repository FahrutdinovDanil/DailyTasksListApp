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
            messagesList.ItemsSource = App.Database.GetRequests().Where(a => a.IdNewUser == idUser);
            base.OnAppearing();
        }
    }
}