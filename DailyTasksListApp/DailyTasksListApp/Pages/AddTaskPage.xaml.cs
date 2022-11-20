using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DailyTasksListApp.SQLite;
using Xamarin.Forms;
using System.Diagnostics;
using System.IO;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace DailyTasksListApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddTaskPage : ContentPage
    {
        public int idUser { get; set; }
        public AddTaskPage(int id)
        {
            InitializeComponent();
            idUser = id;
            this.BindingContext = this;
        }
        private async void SaveTask(object sender, EventArgs e)
        {
            Task task = new Task()
            {
                Name = entName.Text,
                Discription = entDiscription.Text,
                IdUser = idUser
            };
            if (!String.IsNullOrEmpty(task.Name))
            {
                App.Database.SaveTask(task);
            }
            await this.Navigation.PopAsync();
        }

        private void Cancel(object sender, EventArgs e)
        {
            this.Navigation.PopAsync();
        }
    }
}