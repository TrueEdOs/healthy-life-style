using HLS.Models;
using HLS.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HLS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewExercisePage : ContentPage
	{
        NewExerciseViewModel viewModel;

        public NewExercisePage() : this(new Exercise()) { }
		public NewExercisePage (Exercise exercise)
		{
			InitializeComponent ();
            viewModel = new NewExerciseViewModel(exercise);
            BindingContext = viewModel;
            BodyPartList.ItemsSource = App.bodyPartsList;

            BodyPartList.SelectedIndexChanged += (sender, e) =>
            {
                viewModel.Properties = (string)BodyPartList.SelectedItem;
            };

            AcceptButton.Clicked += (sender, e) =>
            {
                if (viewModel.Accept())
                    this.Navigation.PopAsync();
            };
		}
	}
}