using HLS.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HLS.ViewModels
{
    public class NewDishViewModel
    {
        private Dish editableDish;
        public string Description { get { return editableDish.Description; } set { editableDish.Description = value; } }
        public string Name { get { return editableDish.Name; } set { editableDish.Name = value; }}
        public string Properties { get { return editableDish.Properties; } set { editableDish.Properties = value; } }

        public string CalloriesSpend {
            get { return editableDish.CalloriesSpend.ToString(); }
            set {
                double x = 0;
                double.TryParse(value, out x);
                editableDish.CalloriesSpend = x;
            }
        }

        public string ProteinsSpend
        {
            get { return editableDish.ProteinsSpend.ToString(); }
            set
            {
                double x = 0;
                double.TryParse(value, out x);
                editableDish.ProteinsSpend = x;
            }
        }

        public string CarbohydratesSpend
        {
            get { return editableDish.CarbohydratesSpend.ToString(); }
            set
            {
                double x = 0;
                double.TryParse(value, out x);
                editableDish.CarbohydratesSpend = x;
            }
        }

        public string FatsSpend
        {
            get { return editableDish.FatsSpend.ToString(); }
            set
            {
                double x = 0;
                double.TryParse(value, out x);
                editableDish.FatsSpend = x;
            }
        }

        public NewDishViewModel(Dish dish)
        {
            editableDish = dish;
        }

        public bool Accept()
        {
            if(App.Database.Dishes.Contains(editableDish))
            {
                App.Database.Dishes.Remove(editableDish);
            }

            App.Database.Dishes.Add(editableDish);
            return true;
        }
    }
}
