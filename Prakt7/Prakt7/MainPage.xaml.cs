using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Prakt7
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void TabbedPage_Focused(object sender, FocusEventArgs e)
        {
           
        }

        private void TabbedPage_CurrentPageChanged(object sender, EventArgs e)
        {
            try
            {
                if (CurrentPage is InputTable)
                {
                    var page = CurrentPage as InputTable;

                    page.Refresh();
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
