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
    public partial class SendRequestPage : ContentPage
    {
        public int idUser { get; set; }
        public User User { get; set; }
        public int idNewUser { get; set; }
        public SendRequestPage(int id, int newId)
        {
            InitializeComponent();
            idUser = id;
            idNewUser = newId;
            User = App.Database.GetUser(idUser);
            this.BindingContext = this;
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }

        private async void SendRequest(object sender, EventArgs e)
        {
            List<Request> checkReq = App.Database.GetRequests().Where(a => (a.IdUser == idUser || a.IdNewUser == idUser) && (a.IdNewUser == idNewUser || a.IdUser == idNewUser) && ((a.IsReceived == true || a.IsNotReceived == true) || (a.IsReceived == false && a.IsNotReceived == false))).ToList();

            if (checkReq.Count == 0)
            {
                Request request = new Request()
                {
                    IdNewUser = idNewUser,
                    NameNewUser = App.Database.GetUser(idNewUser).Name,
                    NameUser = User.Name,
                    IdUser = idUser,
                    Message = entMessage.Text
                };
                App.Database.SaveRequest(request);
                await Navigation.PushAsync(new UsersTabbedPage(idUser));
            }
            else
            {
                await DisplayAlert(" ", $"У вас уже есть заявка или пользователь находиться в списке ваших друзьях, проверьте!", "ОК");
            }
            

            
        }
    }
}