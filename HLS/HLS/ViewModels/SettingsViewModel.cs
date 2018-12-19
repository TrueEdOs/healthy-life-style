using System;
using System.Collections.Generic;
using System.Text;

namespace HLS.ViewModels
{
    public class SettingsViewModel
    {
        public SettingsViewModel()
        {

        }

        public void ClearMeals()
        {
            App.Database.MealsRepository.Clear();
        }

        public void ClearDishes()
        {
            App.Database.DishesRepository.Clear();
        }

        public void ClearTrainings()
        {
            App.Database.TrainingsRepository.Clear();
        }

        public void ClearExercises()
        {
            App.Database.ExercisesRepository.Clear();
        }
    }
}
