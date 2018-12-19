using HLS.Models;
using HLS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HLS.ViewModels
{
    public class NewExistingExerciseViewModel
    {
        public Exercise Exercise { get; set; }
        public string Count { get; set; }
        public ObservableCollection<ExistingExercise> collection;

        public NewExistingExerciseViewModel(ObservableCollection<ExistingExercise> collection)
        {
            this.collection = collection;
        }

        public async void Accept(ContentPage page)
        {
            double x = 0;
            if (!double.TryParse(Count, style: NumberStyles.Number, provider: CultureInfo.InvariantCulture, result: out x))
            {
                Debug.Print("SIGN166");
                return;
            }
            collection.Add(new ExistingExercise { Exercise = Exercise, Count = x });
            await page.Navigation.PopAsync();
        }

        public async void CreateNewExercise(ContentPage page)
        {
            await page.Navigation.PushAsync(new NewExercisePage());
        }
    }
}
