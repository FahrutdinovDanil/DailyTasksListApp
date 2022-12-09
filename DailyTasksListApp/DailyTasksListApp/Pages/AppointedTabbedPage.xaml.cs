using DailyTasksListApp.Pages.AppointedPages;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTasksListApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppointedTabbedPage : TabbedPage
    {
        public int idUser { get; set; }
        public AppointedTabbedPage(int id)
        {
            InitializeComponent();
            idUser = id;

            Children.Add(new AppointedMeTasksPage(idUser));
            Children.Add(new SendedTasksPage(idUser));

            this.BindingContext = this;
        }
    }
}