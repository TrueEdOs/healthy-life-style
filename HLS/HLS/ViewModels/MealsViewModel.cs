using HLS.Models;
using HLS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace HLS.ViewModels
{
    public class MealsViewModel
    {
        public ObservableCollection<Meal> Meals { get; set; }

        public MealsViewModel(ObservableCollection<Meal> meals)
        {
            Meals = meals;
        }

        public async void AddNewMeal(ContentPage page)
        {
            await page.Navigation.PushAsync(new NewMealPage());
        }
    }
}
