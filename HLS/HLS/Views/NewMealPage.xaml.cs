using HLS.Structures;
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
	public partial class NewMealPage : ContentPage
	{
		public NewMealPage ()
		{
			InitializeComponent ();
            AcceptButton.Clicked += (sender, e) => Accept();
		}

        void Accept()
        {
            BaseLifeUnit bls = new BaseLifeUnit();
            bls.Callories = int.Parse(CalloriesEntry.Text);
            bls.Description = DescriptionEntry.Text;
            App.Meals.Add(bls);
            this.Navigation.PopModalAsync();
        }
	}
}