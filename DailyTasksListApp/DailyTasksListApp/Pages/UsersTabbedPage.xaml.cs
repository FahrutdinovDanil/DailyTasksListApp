using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DailyTasksListApp.Pages.TabPages;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTasksListApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UsersTabbedPage : TabbedPage
    {
        public int idUser { get; set; }
        public UsersTabbedPage(int id)
        {
            InitializeComponent();
            idUser = id;

            Children.Add(new UsersPage(idUser));
            Children.Add(new FriendsPage(idUser));
            Children.Add(new NotificationsPage(idUser));

            this.BindingContext = this;
        }
    }
}