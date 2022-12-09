using DailyTasksListApp.SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DailyTasksListApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrationPage : ContentPage
    {
        public string pathName;
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void UpdateList()
        {
            userPhoto.Source = pathName;
            this.BindingContext = this;
        }

        private async void GetPhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.PickPhotoAsync();
                pathName = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
            UpdateList();
        }

        private async void TakePhotoAsync(object sender, EventArgs e)
        {
            try
            {
                var photo = await MediaPicker.CapturePhotoAsync(new MediaPickerOptions
                {
                    Title = $"xamarin.{DateTime.Now.ToString("dd.MM.yyyy_hh.mm.ss")}.png"
                });

                var newFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), photo.FileName);
                using (var stream = await photo.OpenReadAsync())
                using (var newStream = File.OpenWrite(newFile))
                    await stream.CopyToAsync(newStream);

                Debug.WriteLine($"Путь фото {photo.FullPath}");

                pathName = photo.FullPath;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Сообщение об ошибке", ex.Message, "OK");
            }
            UpdateList();
        }

        private async void btnRegistrClicked(object sender, EventArgs e)
        {
            User user = new User()
            {
                Name = nameEntry.Text,
                Surname = surnameEntry.Text,
                Email = emailEntry.Text,
                PhotoPath = pathName,
                Password = passwordEntry.Text
            };
            if (!String.IsNullOrEmpty(user.Email) && !String.IsNullOrEmpty(user.Password))
            {
                if (passwordEntry.Text == password2Entry.Text)
                    App.Database.SaveUser(user);
                else
                    await DisplayAlert("Ошибка", "Пароли не совпадают", "ОК");
            }
            await this.Navigation.PopAsync();
        }
    }
}