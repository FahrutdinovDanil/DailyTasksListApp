using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTasksListApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointedTasksPage : ContentPage
    {
        public int idUser { get; set; }
        public AppointedTasksPage(int id)
        {
            InitializeComponent();
            idUser = id;
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            tasksList.ItemsSource = App.Database.GetMessagesId(idUser);
            base.OnAppearing();
        }
    }
}