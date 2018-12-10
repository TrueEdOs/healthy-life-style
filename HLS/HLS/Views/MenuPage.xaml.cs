using System;
using System.Collections.Generic;
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
        private List<MenuItem> Items;
        MainPage MainPage { get => (MainPage)Application.Current.MainPage; }

        public MenuPage()
        {

            InitializeComponent();
            Items = new List<MenuItem>{
                new MenuItem {ID = 0, Title = "FrontPage"},
                new MenuItem {ID = 1, Title = "Meals"},
                new MenuItem {ID = 2, Title = "Trainings"},
                new MenuItem {ID = 3, Title = "About"}
            };

            ListViewMenu.ItemsSource = Items;
            ListViewMenu.SelectedItem = 0;
            ListViewMenu.SelectedItem = Items[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;


                await MainPage.NavigateToPage(((MenuItem)((ListView)sender).SelectedItem).ID);

            };
        }

        private class MenuItem
        {
            public int ID { get; set; }
            public String Title { get; set; }
        }


    }
}