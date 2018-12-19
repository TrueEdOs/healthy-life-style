using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HLS.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        MainPage MainPage { get => (MainPage)Application.Current.MainPage; }

        public MenuPage(List<MainPage.MenuItem> Items) 
        {

            InitializeComponent();

            ListViewMenu.ItemsSource = Items;
            ListViewMenu.SelectedItem = 0;
            ListViewMenu.SelectedItem = Items[0];
            
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                try
                {
                    await MainPage.NavigateToPage(((MainPage.MenuItem)((ListView)sender).SelectedItem).ID);
                }
                catch (Exception ee)
                {
                    Debug.Print(ee.ToString());
                }
            };
        }  
    }
}