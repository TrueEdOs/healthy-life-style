using HLS.Models;
using HLS.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace HLS.ViewModels
{
    public class NewMealViewModel : INotifyPropertyChanged
    {
        private Meal meal;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public string Name { get { return meal.Name; } set { meal.Name = value; } }
        public string Description { get { return meal.Description; } set { meal.Description = value; } }
        public double Calories { get { return meal.Calories; } set { meal.Calories = value; } }
        public string DishesList {
            get
            {
                if (meal.Dishes.Count == 0)
                    return "There are nothing there!";
                string res = "";
                foreach(var x in meal.Dishes)
                {
                    res += x.Dish.Name + " " + x.Amount + " gramm\n" ;
                }
                return res;
            }
            set { OnPropertyChanged("DishesList"); }
        }

        public NewMealViewModel(Meal meal)
        {
            this.meal = meal;
            DishesList = "There are nothing there!";
            meal.Dishes.CollectionChanged += (sender, e) =>
            {
                DishesList = "";
                foreach(var x in meal.Dishes)
                {
                    DishesList += x.Dish.Name + " " + x.Amount + " gramm";
                }
                if(meal.Dishes.Count == 0)
                    DishesList = "There are nothing there!";
            };
        }

        public bool Accept()
        {
            App.Database.MealsRepository.AddOrUpdate(meal);
            return true;
        }

        public void CorrectDishes(ContentPage page)
        {
            page.Navigation.PushAsync(new BasicListPage<ExistingDish>(meal.Dishes, ()=> { return new NewExistingDishPage(meal.Dishes); }));
        }
    }
}
