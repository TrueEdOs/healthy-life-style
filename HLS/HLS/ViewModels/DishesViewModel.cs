using HLS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HLS.ViewModels
{
    public class DishesViewModel
    {
        public Dish selectedDish = null;
        //public O
        public class DishRepresentation
        {
            public String Name { get; set; }
            public String Count { get; set; }
            public Dish Original { get; set; }
        }

        public DishesViewModel(Meal meal)
        {

        }

        public void AddDish(ContentPage page)
        {

        }

        public void CorrectDish(ContentPage page)
        {

        }

        public void DeleteDish()
        {

        }
    }
}
