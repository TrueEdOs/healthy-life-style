﻿using HLS.Models;
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
	public partial class NewExistingDishPage : ContentPage
	{
        private ObservableCollection<Tuple<Dish, double>> collectionToChange;
        public string Count { get; set; }
        public Dish selectedDish = null;
		public NewExistingDishPage (ObservableCollection<Tuple<Dish, double>> collection)
		{
			InitializeComponent ();
            collectionToChange = collection;
            App.Database.Dishes.CollectionChanged += (sender, e) => 
            {
                DishPicker.Items.Clear();
                foreach(var x in App.Database.Dishes)
                {
                    DishPicker.Items.Add(x.Name);
                }
                DishPicker.Items.Add("Add new....");
            };
            AcceptButton.Clicked += (sender, e)=>
            {
                if (selectedDish != null && double.TryParse(Count, out double x))
                {
                    collectionToChange.Add(new Tuple<Dish, double>(selectedDish, x));
                    this.Navigation.PopAsync();
                }
            };
        }

        private void DishPicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DishPicker.SelectedIndex == collectionToChange.Count)
                AddNewDish();
            else
                selectedDish = App.Database.Dishes[DishPicker.SelectedIndex];
        }

        private void AddNewDish()
        {
            this.Navigation.PushAsync(new NewDishPage(new Dish()));
        }
    }
}