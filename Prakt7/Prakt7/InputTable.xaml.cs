using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prakt7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InputTable : ContentPage
    {
        public (string name, string surname, string middleName, string gender, DateTime birthDate, bool isLeader, bool needRoom, int rpmMark, int rmpMark, int trpoMark) user;
        public InputTable()
        {
            InitializeComponent();
        }

        private void AddUserInfo_Click(object sender, EventArgs e)
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
            }
            catch
            {
                DisplayAlert("Ошибка", "Введены неверные данные", "Отмена");
                return;
            }
            
        }
        public void AddMarks(string a, string b, string c)
            {
            user.rmpMark = Convert.ToInt32(a);
            user.rpmMark = Convert.ToInt32(b);
            user.trpoMark = Convert.ToInt32(c);
            }
    }
}