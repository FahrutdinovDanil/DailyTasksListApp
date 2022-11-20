using DailyTasksListApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace DailyTasksListApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}