using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prakt7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ModalPage : ContentPage
    {
        
        public ModalPage()
        {
            InitializeComponent();
        }

       async private void Close_Modal(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async Task addInfoAsync(object sender, EventArgs e)
        {
            try
            {
                InputTable.user.name = nameEntry.Text;
                InputTable.user.surname = surnameEntry.Text;
                InputTable.user.middleName = middleNameEntry.Text;
                InputTable.user.gender = gender.SelectedItem.ToString();
                InputTable.user.birthDate = agePicker.Date;
                if (isLeader.SelectedItem == "Да") InputTable.user.isLeader = true;
                else InputTable.user.isLeader = false;
                if (isLeader.SelectedItem == "Да") InputTable.user.isLeader = true;
                else InputTable.user.isLeader = false;
                var options = new PickOptions
                {
                    PickerTitle = "Выберите фото",
                    FileTypes = FilePickerFileType.Images,
                };
                if (Device.RuntimePlatform == Device.Android)
                {
                    var result = await FilePicker.PickAsync(options);
                    InputTable._imagePath = result.FullPath;
                    imageSection.Source = InputTable._imagePath;
                }

            }
            catch
            {
                DisplayAlert("Ошибка", "Введены неверные данные", "Отмена");
                return;
            }
            InputTable.SavePrefs(); 
            Navigation.PopModalAsync();
        }
    }
}