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
    public partial class EditProductPage : ContentPage
    {
        public EditProductPage(Product product)
        {
            InitializeComponent();
            this.BindingContext = this;
        }
        private async void RemoveProduct(object sender, EventArgs e)
        {
            var product = (Product)BindingContext;
            if (await DisplayAlert(" ", $"Вы хотите удалить {product.Name}?", "Удалить", "Отмена"))
            {
                App.Database.DeleteProduct(product.Id);
                await Navigation.PushAsync(new ProductsPage(product.IdUser));
            }
        }

        private async void SaveProduct(object sender, EventArgs e)
        {
            var product = (Product)BindingContext;
            if (await DisplayAlert(" ", $"Вы хотите изменить {product.Name}?", "Изменить", "Отмена"))
            {
                if (!String.IsNullOrEmpty(product.Name))
                {
                    App.Database.SaveProduct(product);
                }
                await this.Navigation.PopAsync();
            }
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}