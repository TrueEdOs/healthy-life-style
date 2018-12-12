using HLS.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HLS.Views
{
	public class NewExistingPage<T> : ContentPage
	{
        private ObservableCollection<Tuple<T, double>> collectionToChange;
        private readonly ObservableCollection<T> databaseCollection;

        private T selectedValue;
        public string Count { get; set; }
        private bool selected = false;

        public NewExistingPage (ObservableCollection<Tuple<T, double>> collection)
		{
            if (!typeof(T).Equals(typeof(Dish)) && !typeof(T).Equals(typeof(Exercise)))
                throw new NotImplementedException();

            collectionToChange = collection;
            Label chooseLabel = new Label { Text = "Choose " + (typeof(T).Equals(typeof(Dish)) ? "Dish" : "Exercise") };
            Picker valuePicker = new Picker();
            if (typeof(T).Equals(typeof(Dish)))
                databaseCollection = (ObservableCollection<T>)(object)App.Database.Dishes;
            if (typeof(T).Equals(typeof(Exercise)))
                databaseCollection = (ObservableCollection<T>)(object)App.Database.Exercises;

            valuePicker.SelectedIndexChanged += IndexChanged;

            Label countLabel = new Label { Text = "Count" };
            Entry countEntry = new Entry { Keyboard = Keyboard.Numeric};
            countEntry.TextChanged += (sender, e) => { Count = e.NewTextValue; };
            Button acceptButton = new Button { Text = "Accept" };

            databaseCollection.CollectionChanged += (sender, e) =>
            {
                valuePicker.Items.Clear();
                foreach (var x in databaseCollection)
                {
                    if (typeof(T).Equals(typeof(Dish)))
                        valuePicker.Items.Add(((Dish)(object)x).Name);

                    if (typeof(T).Equals(typeof(Exercise)))
                        valuePicker.Items.Add(((Exercise)(object)x).Name);
                }
                valuePicker.Items.Add("Add new....");
            };

            foreach (var x in databaseCollection)
            {
                if (typeof(T).Equals(typeof(Dish)))
                    valuePicker.Items.Add(((Dish)(object)x).Name);

                if (typeof(T).Equals(typeof(Exercise)))
                    valuePicker.Items.Add(((Exercise)(object)x).Name);
            }
            valuePicker.Items.Add("Add new....");

            acceptButton.Clicked += (sender, e) =>
            {
                double x;
                Debug.Print(selected + " " + double.TryParse(Count, NumberStyles.Number, CultureInfo.InvariantCulture, out x) + " " + Count);
                if (selected && double.TryParse(Count, NumberStyles.Number, CultureInfo.InvariantCulture, out x))
                {
                    collectionToChange.Add(new Tuple<T, double>(databaseCollection[valuePicker.SelectedIndex], x));
                    this.Navigation.PopAsync();
                }
            };

            

            Content = new StackLayout {
                Children = {
                    chooseLabel,
                    valuePicker,
                    countLabel,
                    countEntry,
                    acceptButton
				}
			};
		}

        private void IndexChanged(object sender, EventArgs e)
        {
            if(((Picker)sender).SelectedIndex == databaseCollection.Count)
            {
                selected = false;
                if (typeof(T).Equals(typeof(Dish)))
                {
                    this.Navigation.PushAsync(new NewDishPage(new Dish()));
                }

                if (typeof(T).Equals(typeof(Exercise)))
                    throw new NotImplementedException();
            }
            else
            {
                selected = true;
            }
        }
	}
}