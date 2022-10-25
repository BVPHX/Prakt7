using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Prakt7
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NavigationPageFlyout : ContentPage
    {
        public ListView ListView;

        public NavigationPageFlyout()
        {
            InitializeComponent();

            BindingContext = new NavigationPageFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        private class NavigationPageFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<NavigationPageFlyoutMenuItem> MenuItems { get; set; }

            public NavigationPageFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<NavigationPageFlyoutMenuItem>(new[]
                {
                    new NavigationPageFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new NavigationPageFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new NavigationPageFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new NavigationPageFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new NavigationPageFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}