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
            this.BindingContext = this;
        }
        private async void SaveMessage(object sender, EventArgs e)
        {
            var user = (User)BindingContext;
            Message message = new Message()
            {
                Name = entName.Text,
                Discription = entDiscription.Text,
                IdUser = user.Id,
                IdNewUser = idUser,
            };
            if (!String.IsNullOrEmpty(message.Name))
            {
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