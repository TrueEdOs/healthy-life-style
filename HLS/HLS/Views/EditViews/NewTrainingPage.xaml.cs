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
	public partial class NewTrainingPage : ContentPage
	{
        NewTrainingViewModel viewModel;
        public NewTrainingPage():this(new Training()) { }
		public NewTrainingPage (Training training)
		{

            viewModel = new NewTrainingViewModel(training);
            BindingContext = viewModel;
            InitializeComponent();
            CorrectButton.Clicked += (sender, e) => { viewModel.Correct(this); };
            AcceptButton.Clicked += (sender, e) => { if (viewModel.Accept()) this.Navigation.PopAsync(); };
		}
	}
}