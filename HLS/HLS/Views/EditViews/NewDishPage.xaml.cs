using HLS.Models;
using HLS.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HLS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewDishPage : ContentPage
	{
        public NewDishViewModel viewModel;
        
        public NewDishPage():this(new Dish())
        { }

        public NewDishPage (Dish dish)
		{
            
            InitializeComponent();
            viewModel = new NewDishViewModel(dish);
            BindingContext = viewModel;
            AcceptButton.Clicked += (sender, e)=>
            {
                if (viewModel.Accept())
                    this.Navigation.PopAsync();
            }; 
        }
    }
}