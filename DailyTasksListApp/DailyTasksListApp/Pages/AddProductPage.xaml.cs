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
    public partial class AddProductPage : ContentPage
    {
        public int idUser { get; set; }
        public AddProductPage(int id)
        {
            InitializeComponent();
            idUser = id;
            this.BindingContext = this;
        }
        private async void SaveProduct(object sender, EventArgs e)
        {
            Product product = new Product()
            {
                Name = entName.Text,
                Count = Convert.ToInt32(entCount.Text),
                CountType = pickerUnit.SelectedItem.ToString(),
                Discription = entDicription.Text,
                IdUser = idUser
            };
            if (!String.IsNullOrEmpty(product.Name))
            {
                App.Database.SaveProduct(product);
            }
            await this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}