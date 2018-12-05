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
	public partial class DishesPage : ContentPage
	{
        private Meal meal;
        private DishesViewModel viewModel;

        public DishesPage(Meal meal)
        {
            viewModel = new DishesViewModel(meal);
            BindingContext = viewModel;
            InitializeComponent();

            ToolbarItems.Add(new ToolbarItem("", "addIcon.xml", () =>
            { viewModel.AddDish(this); }));

            ToolbarItems.Add(new ToolbarItem("", "checkIcon.xml", () =>
            { viewModel.CorrectDish(this); }));

            ToolbarItems.Add(new ToolbarItem("", "deleteIcon.xml", () =>
            { viewModel.DeleteDish(); }));
        }
    }
}