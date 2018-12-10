using HLS.Models;
using HLS.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HLS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewMealPage : ContentPage
	{
        private NewMealViewModel viewModel;
		public NewMealPage ()
		{
            viewModel = new NewMealViewModel(new Meal(false));
            BindingContext = viewModel;
			InitializeComponent ();

            CorrectDishesButton.Clicked += (sender, e) =>
            {
                viewModel.CorrectDishes(this);
            };

            AcceptButton.Clicked += (sender, e) => {
                if (viewModel.Accept())
                {
                    this.Navigation.PopAsync();
                }
            };
		}
	}
}