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
	public partial class TrainingsPage : ContentPage
	{
        List<Tuple<string, string>> list = new List<Tuple<string, string>>();
		public TrainingsPage ()
		{
			InitializeComponent ();
            Tuple<string, string> x = new Tuple<string, string>( "s", "sd" );
            list.Add(x);
            TrainingsListView.ItemsSource = list;
		}
	}
}