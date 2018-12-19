using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;
using HLS.Views;

namespace HLS.Models
{
    public class ExistingDish : IModel<ExistingDish>
    {
        public Meal Meal { get; set; }
        public Dish Dish { get; set; }

        public double Amount { get; set; }

        public string Title => Dish.Name;

        public string Description => "Amount " + Amount + " gramm";

        public ContentPage EditablePage => throw new NotImplementedException();

        public ObservableCollection<ExistingDish> Collection => Meal.Dishes;

    }
}
