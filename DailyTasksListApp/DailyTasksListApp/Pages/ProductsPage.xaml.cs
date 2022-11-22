using DailyTasksListApp.Pages;
using DailyTasksListApp.SQLite;
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
    public partial class ProductsPage : ContentPage
    {
        public int idUser { get; set; }
        public ProductsPage(int id)
        {
            InitializeComponent();
            idUser = id;
            this.BindingContext = this;
        }
        protected override void OnAppearing()
        {
            productsList.ItemsSource = App.Database.GetProductsId(idUser);
            base.OnAppearing();
        }

        private async void AddProduct(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddProductPage(idUser));
        }

        private async void productsList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Product selectedProject = (Product)e.SelectedItem;
            EditProductPage projectPage = new EditProductPage(selectedProject);
            projectPage.BindingContext = selectedProject;
            await Navigation.PushAsync(projectPage);
        }
    }
}