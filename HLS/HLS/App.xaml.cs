using HLS.Structures;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HLS
{
    public partial class App : Application
    {
        public static ObservableCollection<BaseLifeUnit> Meals = new ObservableCollection<BaseLifeUnit>();

        public App()
        {
            InitializeComponent();

            MainPage = new Views.MainPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
