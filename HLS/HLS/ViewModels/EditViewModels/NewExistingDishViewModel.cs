using HLS.Models;
using HLS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace HLS.ViewModels
{
    public class NewExistingDishViewModel
    {
        public Dish Dish { get; set; }
        public string Amount { get; set; }
        public ObservableCollection<ExistingDish> collection;

        public NewExistingDishViewModel(ObservableCollection<ExistingDish> collection)
        {
            this.collection = collection;
        }

        public async void Accept(ContentPage page)
        {
            double x = 0;
            if (!double.TryParse(Amount, style: NumberStyles.Number, provider: CultureInfo.InvariantCulture, result: out x))
            {
                return;
            }
            collection.Add(new ExistingDish { Dish = Dish, Amount = x });
            await page.Navigation.PopAsync();
        }

        public async void CreateNewDish(ContentPage page)
        {
            await page.Navigation.PushAsync(new NewDishPage());
        }
    }
}
