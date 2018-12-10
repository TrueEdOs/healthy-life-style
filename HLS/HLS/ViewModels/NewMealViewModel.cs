using HLS.Models;
using HLS.Views;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace HLS.ViewModels
{
    public class NewMealViewModel
    {
        private Meal meal;
        
        public string Name { get { return meal.Name; } set { meal.Name = value; } }
        public string Description { get { return meal.Description; } set { meal.Description = value; } }
        public double Calories { get { return meal.Calories; } set { meal.Calories = value; } }
        public string CaloriesText { get { return Calories.ToString(); } set {
                try { Calories = double.Parse(value); Debug.Print("Right + " + value); } catch (Exception e) { Debug.Print("Wrong + " + value); } } }

        public NewMealViewModel(Meal meal)
        {
            this.meal = meal;  
        }

        public bool Accept()
        {
            App.Database.Meals.Add(meal);
            return true;
        }

        public void CorrectDishes(ContentPage page)
        {
            page.Navigation.PushAsync(new BasicListPage<Tuple<Dish, double>>(meal.Dishes));
        }
    }
}
