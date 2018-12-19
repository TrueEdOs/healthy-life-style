using HLS.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace HLS.ViewModels
{
    public class NewExerciseViewModel
    {
        private Exercise editableExercise;
        public string Description { get { return editableExercise.Description; } set { editableExercise.Description = value; } }
        public string Name { get { return editableExercise.Name; } set { editableExercise.Name = value; Debug.Print("SIGN155" + value); } }
        public string Properties { get { return editableExercise.Properties; } set { editableExercise.Properties = value; } }

        public string CaloriesSpend
        {
            get { return editableExercise.CaloriesSpend.ToString(); }
            set
            {
                double x = 0;
                double.TryParse(value, out x);
                editableExercise.CaloriesSpend = x;
            }
        }
        
        public NewExerciseViewModel(Exercise exercise)
        {
            editableExercise = exercise;
        }

        public bool Accept()
        {
            App.Database.ExercisesRepository.AddOrUpdate(editableExercise);
            return true;
        }
    }
}
