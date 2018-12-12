using System;

/*
 * I am so sorry. This is bad code, someone rewrite it please!!!!
 */

namespace HLS.Models
{
    class BasicRepresentationModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public object Original { get; set; }
        
        public BasicRepresentationModel(object o)
        {
            if(o is Meal)
            {
                Init((Meal)o);
                return;
            }

            if(o is Dish)
            {
                Init((Dish)o);
                return;
            }

            if (o is Tuple<Dish, double>)
            {
                Init((Tuple<Dish, double>)o);
                return;
            }

            throw new NotImplementedException();
        }


        private void Init(Meal meal)
        {
            Title = meal.Name;
            Description = meal.Calories.ToString();
        }

        private void Init(Dish dish)
        {
            Title = dish.Name;
            Description = dish.CalloriesSpend.ToString();
        }

        private void Init(Tuple<Dish, double> dish)
        {
            Title = dish.Item1.Name;
            Description = "Count " + dish.Item2;
        }
   

        public BasicRepresentationModel(Training training)
        {
            Title = training.Name;
            Description = training.Calories.ToString();
        }

        public BasicRepresentationModel(Exercise exercise)
        {
            Title = exercise.Name;
            Description = exercise.CalloriesSpend.ToString();
        }

        public BasicRepresentationModel(Tuple<Exercise, double> exercise)
        {
            Title = exercise.Item1.Name;
            Description = "Count " + exercise.Item2;
        }

    }
}
