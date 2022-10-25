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
    public partial class SafePage : ContentPage
    {
        public SafePage()
        {
            InitializeComponent();
        }

         async private void Ent_Changed(object sender, TextChangedEventArgs e)
        {
            if (passwordEntry.Text.Length == 3 && passwordEntry.Text == "123")
                await Navigation.PopAsync();
        }

        private void EnteringPassword(object sender, EventArgs e)
        {
            var xxx = sender as Button;
            switch (xxx.Text)
            {
                case "1":
                    passwordEntry.Text += xxx.Text; break;
                case "2":
                    passwordEntry.Text += xxx.Text; break;
                case "3":
                    passwordEntry.Text += xxx.Text; break;
                case "4":
                    passwordEntry.Text += xxx.Text; break;
                case "5":
                    passwordEntry.Text += xxx.Text; break;
                case "6":
                    passwordEntry.Text += xxx.Text; break;
                case "7":
                    passwordEntry.Text += xxx.Text; break;
                case "8":
                    passwordEntry.Text += xxx.Text; break;
                case "9":
                    passwordEntry.Text += xxx.Text; break;
                case "0":
                    passwordEntry.Text += xxx.Text; break;
                case "Стереть":
                    passwordEntry.Text = passwordEntry.Text.Remove(passwordEntry.Text.Length - 1); ; break;
            }
        }
    }
}