using HLS.Models;
using HLS.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HLS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewExistingExercisePage : ContentPage
	{
        NewExistingExerciseViewModel viewModel;

        public NewExistingExercisePage (ObservableCollection<ExistingExercise> collection)
		{
			InitializeComponent ();
            viewModel = new NewExistingExerciseViewModel(collection);
            
            BindingContext = viewModel;
            
                
            ExercisePicker.SelectedIndexChanged += (sender, e) =>
            {
                if (ExercisePicker.SelectedIndex >= App.Database.ExercisesRepository.Collection.Count)
                {
                    viewModel.CreateNewExercise(this);
                    ExercisePicker.SelectedIndex = App.Database.ExercisesRepository.Collection.Count - 1;
                    return;
                }
                
                
                if (ExercisePicker.SelectedIndex != -1)
                    viewModel.Exercise = App.Database.ExercisesRepository.Collection[ExercisePicker.SelectedIndex];
            };

            AcceptButton.Clicked += (sender, e) => {
                Debug.Print("SIGN160");
                viewModel.Accept(this);
            };

            foreach (var x in App.Database.ExercisesRepository.Collection)
            {
                ExercisePicker.Items.Add(x.Title);
            }

            ExercisePicker.Items.Add("Add new...");

            App.Database.ExercisesRepository.Collection.CollectionChanged += (sender, e) =>
            {
                ExercisePicker.Items.Clear();

                foreach (var x in App.Database.ExercisesRepository.Collection)
                {
                    ExercisePicker.Items.Add(x.Title);
                }
                ExercisePicker.SelectedIndex = ExercisePicker.Items.Count - 1;
                ExercisePicker.Items.Add("Add new...");
            };
        }
 
	}
}