using HLS.Models;
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
    public partial class MainPage : MasterDetailPage
    {
        public static Dictionary<int, NavigationPage> Pages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
  
            Master = new MenuPage();
            Detail = new NavigationPage(new FrontPage());
            InitializeComponent();
        }

        public async Task NavigateToPage(int pageId)
        {
            if (!Pages.ContainsKey(pageId))
            {
                switch (pageId)
                {
                    case 0:
                        Pages.Add(pageId, new NavigationPage(new FrontPage()));
                        break;
                    case 1:
                        Pages.Add(pageId, new NavigationPage(new BasicListPage<Meal>(App.Database.Meals)));
                        break;
                    case 2:
                        Pages.Add(pageId, new NavigationPage(new TrainingsPage()));
                        break;
                    case 3:
                        Pages.Add(pageId, new NavigationPage(new About()));
                        break;
                }
            }

            var newPage = Pages[pageId];
            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;
                if (Device.RuntimePlatform == Device.Android)
                {
                    await Task.Delay(105);
                }
                 IsPresented = false;
           }
        }
    }
}