using HLS.Models;
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
        public static List<string> bodyPartsList = new List<string>();
        public static readonly HealthyLifeStyleDataBase Database = new HealthyLifeStyleDataBase("HLS.db3");
        public delegate ContentPage CreatePage();
        public App()
        {
            InitializeComponent();
            bodyPartsList.Add("Hands");
            bodyPartsList.Add("Shoulders");
            bodyPartsList.Add("Legs");
            bodyPartsList.Add("Chest");
            bodyPartsList.Add("Press");
            bodyPartsList.Add("Neck");
            bodyPartsList.Add("Heart");
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
