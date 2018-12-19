using HLS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace HLS.Models
{
    public class ExistingExercise : IModel<ExistingExercise>
    {
        public Training Training { get; set; }
        public Exercise Exercise { get; set; }
        
        public double Count { get; set; }

        public string Title => Exercise.Name;

        public string Description => "Done " + Count + " times";
        public ContentPage EditablePage => throw new NotImplementedException();
        public ObservableCollection<ExistingExercise> Collection => Training.Exercises;
    }
}
