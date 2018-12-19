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
        public static List<MenuItem> CreatablePages = new List<MenuItem>();
        public class MenuItem
        {
            public int ID { get; set; }
            public String Title { get; set; }
            public App.CreatePage CreatePage { get; set; }
            public static int cnt = 0;
            public MenuItem() { ID = cnt++; }
        }

        public MainPage()
        {
            CreatablePages.Add(new MenuItem
            {
                Title = "Front page",
                CreatePage = () => new FrontPage()
            });
            CreatablePages.Add(new MenuItem
            {
                Title = "Meals",
                CreatePage = () => new BasicListPage<Meal>(App.Database.MealsRepository.Collection, () => new NewMealPage())
            });
            CreatablePages.Add(new MenuItem
            {
                Title = "Training",
                CreatePage = () => new BasicListPage<Training>(App.Database.TrainingsRepository.Collection, () => new NewTrainingPage())
            });
            CreatablePages.Add(new MenuItem
            {
                Title = "Dishes",
                CreatePage = () => new BasicListPage<Dish>(App.Database.DishesRepository.Collection, () => new NewDishPage())
            });
            CreatablePages.Add(new MenuItem
            {
                Title = "Exercises",
                CreatePage = () => new BasicListPage<Exercise>(App.Database.ExercisesRepository.Collection, () => new NewExercisePage())
            });
            CreatablePages.Add(new MenuItem
            {
                Title = "About",
                CreatePage = () => new About()
            });
            Master = new MenuPage(CreatablePages);
            Detail = new NavigationPage(new FrontPage());
            InitializeComponent();
        }

        public async Task NavigateToPage(int pageId)
        {
            if (!Pages.ContainsKey(pageId))
            {
                Pages.Add(pageId, new NavigationPage(CreatablePages[pageId].CreatePage.Invoke()));
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