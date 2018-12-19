using HLS.Models;
using HLS.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HLS.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class NewExistingDishPage : ContentPage
	{
        public NewExistingDishViewModel viewModel;
       

        public NewExistingDishPage (ObservableCollection<ExistingDish> collection)
		{
			InitializeComponent ();
            viewModel = new NewExistingDishViewModel(collection);
            BindingContext = viewModel;
            
            DishPicker.SelectedIndexChanged += (sender, e) =>
            {
                if(DishPicker.SelectedIndex >= App.Database.DishesRepository.Collection.Count)
                {
                    viewModel.CreateNewDish(this);
                    DishPicker.SelectedIndex = App.Database.DishesRepository.Collection.Count - 1;
                    return;
                }
                if(DishPicker.SelectedIndex != -1)
                    viewModel.Dish = App.Database.DishesRepository.Collection[DishPicker.SelectedIndex];
            };
            
            AcceptButton.Clicked += (sender, e) => {       
                viewModel.Accept(this);
            };

            foreach (var x in App.Database.DishesRepository.Collection)
            {
                DishPicker.Items.Add(x.Title);
            }

            DishPicker.Items.Add("Add new...");

            App.Database.DishesRepository.Collection.CollectionChanged += (sender, e) =>
            {
                //Debug.Print("SIGN92 - DishAdded");
                DishPicker.Items.Clear();

                foreach(var x in App.Database.DishesRepository.Collection)
                {
                    DishPicker.Items.Add(x.Title);
                }
                DishPicker.SelectedIndex = DishPicker.Items.Count - 1;
                DishPicker.Items.Add("Add new...");
            };
		}
	}
}