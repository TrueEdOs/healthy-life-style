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
    public class NewTrainingViewModel : INotifyPropertyChanged
    {
        private Training training;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public string Name { get { return training.Name; } set { training.Name = value; } }
        public string Description { get { return training.Description; } set { training.Description = value; } }
        
        public string ExercisesList
        {
            get
            {
                if (training.Exercises.Count == 0)
                    return "There are nothing there!";
                string res = "";
                foreach (var x in training.Exercises)
                {
                    res += x.Exercise.Name + " " + x.Count + " times";
                }
                return res;
            }
            set { }
        }

        public NewTrainingViewModel(Training training)
        {
            this.training = training;
            ExercisesList = "There are nothing there!";
            training.Exercises.CollectionChanged += (sender, e) =>
            {
                ExercisesList = "";
                foreach (var x in training.Exercises)
                {
                    ExercisesList += x.Exercise.Name + " " + x.Count + " gramm";
                }
                if (training.Exercises.Count == 0)
                    ExercisesList = "There are nothing there!";
            };
        }

        public bool Accept()
        {
            App.Database.TrainingsRepository.AddOrUpdate(training);
            return true;
        }

        public void Correct(ContentPage page)
        {
            page.Navigation.PushAsync(new BasicListPage<ExistingExercise>(training.Exercises, () => { return new NewExistingExercisePage(training.Exercises); }));
        }
    }
}

