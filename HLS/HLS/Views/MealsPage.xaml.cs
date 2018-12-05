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
	public partial class MealsPage : ContentPage
	{
        private MealsViewModel viewModel;
		public MealsPage ()
		{
            viewModel = new MealsViewModel(App.Database.Meals);
            BindingContext = viewModel;

            InitializeComponent ();

            ToolbarItems.Add(new ToolbarItem("", "addIcon.xml", () =>
            { viewModel.AddNewMeal(this); }));
        }

        
	}
}