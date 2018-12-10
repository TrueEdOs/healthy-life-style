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
	public partial class NewDishPage : ContentPage
	{
        public NewDishViewModel viewModel;
		public NewDishPage (Dish dish)
		{
			InitializeComponent ();
		}
	}
}