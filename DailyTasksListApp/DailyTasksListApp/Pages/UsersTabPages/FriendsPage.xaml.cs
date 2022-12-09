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
    public partial class FriendsPage : ContentPage
    {
        public User User { get; set; }
        public int idUser { get; set; }
        public Request request { get; set; }
        public FriendsPage(int IdUser)
        {
            InitializeComponent();
            Title = "Друзья";
            idUser = IdUser;
            User = App.Database.GetUserId(IdUser);
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            List<User> users = new List<User>();
            List<Friend> friends = App.Database.GetFriends().Where(x => x.IdUser == idUser || x.IdNewUser == idUser).ToList();
            foreach (Friend friend in friends)
            {
                if (friend.IdUser == idUser)
                {
                    users.Add(App.Database.GetUser(friend.IdNewUser));
                }
                else
                {
                    users.Add(App.Database.GetUser(friend.IdUser));
                }

            }
            friendsList.ItemsSource = users;

            base.OnAppearing();
        }

        private async void friendsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            User selectedUser= (User)e.SelectedItem;
            AddMessagePage projectPage = new AddMessagePage(idUser, selectedUser);
            projectPage.BindingContext = selectedUser;
            await Navigation.PushAsync(projectPage);
        }
    }
}