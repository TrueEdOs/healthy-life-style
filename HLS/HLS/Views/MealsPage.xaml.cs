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
        
		public MealsPage ()
		{
			InitializeComponent ();
            ToolbarItems.Add(new ToolbarItem("", "addIcon.xml", () =>
            {
            this.Navigation.PushModalAsync(new NavigationPage(new NewMealPage()));
                System.Diagnostics.Debug.WriteLine(" BUTTON PUSHED");
            }));
            MealsListView.ItemsSource = App.Meals;
        }

        
	}
}