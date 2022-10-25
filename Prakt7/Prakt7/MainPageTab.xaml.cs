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
    public partial class MainPageTab : ContentPage
    {
        public MainPageTab()
        {
            InitializeComponent();
            AuthorizationPageOpen();
        }
        async private void AuthorizationPageOpen()
        {
            await Navigation.PushAsync(new SafePage());
        }

        async private void btn_Safepage(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SafePage());
        }

        async private void btn_ModalPage(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new ModalPage());
        }
    }
}