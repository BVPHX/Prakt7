using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;

namespace Prakt7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputTable : ContentPage
    {
        string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static (string name, string surname, string middleName, string gender, DateTime birthDate, bool isLeader, bool needRoom, int rpmMark, int rmpMark, int trpoMark) user;
        private string _imagePath = string.Empty;
        public InputTable()
        {
            InitializeComponent();
            try { OpenData(); } catch { }
        }

        private async void AddUserInfo_Click(object sender, EventArgs e)
        {

            try
            {
                user.name = nameEntry.Text;
                user.surname = surnameEntry.Text;
                user.middleName = middleNameEntry.Text;
                user.gender = gender.SelectedItem.ToString();
                user.birthDate = agePicker.Date;
                if (isLeader.SelectedItem == "Да") user.isLeader = true;
                else user.isLeader = false;
                if (isLeader.SelectedItem == "Да") user.isLeader = true;
                else user.isLeader = false;
                var options = new PickOptions
                {
                    PickerTitle = "Выберите фото",
                    FileTypes = FilePickerFileType.Images,
                };
                if (Device.RuntimePlatform == Device.Android)
                {
                    var result = await FilePicker.PickAsync(options);
                    _imagePath = result.FullPath;
                    imageSection.Source = _imagePath;
                }

            }
            catch
            {
                DisplayAlert("Ошибка", "Введены неверные данные", "Отмена");
                return;
            }
            //SavindData();
            SavePrefs();
        }
        public static void AddMarks(string a, string b, string c)
        {
            user.rmpMark = Convert.ToInt32(a);
            user.rpmMark = Convert.ToInt32(b);
            user.trpoMark = Convert.ToInt32(c);
        }
        private void SavindData()
        {
            StreamWriter outFile = new StreamWriter(Path.Combine(folderPath, "file1.txt"));
            outFile.WriteLine(user.name);
            outFile.WriteLine(user.surname);
            outFile.WriteLine(user.middleName);
            outFile.WriteLine(user.gender);
            outFile.WriteLine(user.birthDate.ToString());
            outFile.WriteLine(isLeader.ToString());
            outFile.WriteLine(needRoom.ToString());
            outFile.WriteLine(user.trpoMark.ToString());
            outFile.WriteLine(user.rpmMark.ToString());
            outFile.WriteLine(user.rmpMark.ToString());
            outFile.WriteLine(_imagePath);
            outFile.Close();

        }
        private void OpenData()
        {
            if (File.Exists(Path.Combine(folderPath, "file1.txt")) == true)
            {
                StreamReader streamReader = new StreamReader(Path.Combine(folderPath, "file1.txt"));
                user.name = streamReader.ReadLine();
                user.surname = streamReader.ReadLine();
                user.middleName = streamReader.ReadLine();
                user.gender = streamReader.ReadLine();
                user.birthDate = Convert.ToDateTime(streamReader.ReadLine());
                if (streamReader.ReadLine() == "1") user.isLeader = true; else user.isLeader = false;
                if (streamReader.ReadLine() == "1") user.needRoom = true; else user.needRoom = false;
                user.trpoMark = Convert.ToInt32(streamReader.ReadLine());
                user.rpmMark = Convert.ToInt32(streamReader.ReadLine());
                user.rmpMark = Convert.ToInt32(streamReader.ReadLine());
                string imagepath = streamReader.ReadLine();
                nameEntry.Text = user.name;
                imageSection.Source = imagepath;
            }
        }
        private void SavePrefs()
        {
            Preferences.Set("name", user.name);
            Preferences.Set("surname", user.surname);
            Preferences.Set("middlename", user.surname);
            Preferences.Set("gender", user.gender);
            Preferences.Set("birthDate", user.birthDate.ToString());
            Preferences.Set("isLeader", isLeader.ToString());
            Preferences.Set("needroom", needRoom.ToString());
            Preferences.Set("trpoMark", user.trpoMark.ToString());
            Preferences.Set("rpmMark", user.rpmMark.ToString());
            Preferences.Set("rmpMark", user.rmpMark.ToString());
            Preferences.Set("image", imageSection.Source.ToString());

        }
    }
}