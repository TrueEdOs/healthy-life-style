using HLS.Models;
using HLS.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace HLS.ViewModels
{
    class BasicListViewModel<T>
    {
        public ObservableCollection<T> collection;
        public BasicRepresentationModel selectedItem;
        public ObservableCollection<BasicRepresentationModel> RepresentationCollection { get; set; } = new ObservableCollection<BasicRepresentationModel>();

        public BasicListViewModel(ObservableCollection<T> collection)
        {
            this.collection = collection;
            foreach(var x in collection)
            {
                RepresentationCollection.Add(new BasicRepresentationModel((T)x));
            }

            RepresentationCollection.CollectionChanged += (sender, e) =>
            {
                if (e.OldItems == null)
                    return;
                foreach (var x in e.OldItems)
                    if (collection.Contains((T)((BasicRepresentationModel)x).Original))
                    {
                        collection.Remove((T)((BasicRepresentationModel)x).Original);
                    }
            };

            collection.CollectionChanged += (sender, e) =>
            {
                if (e.NewItems == null)
                    return;
                foreach (var x in e.NewItems)
                {
                    if ((T)x is Meal)
                        Debug.Print("ASFASKHF");
                    RepresentationCollection.Add(new BasicRepresentationModel((T)x));
                }
            };
        }

        public async void Add(ContentPage page)
        {
            if (typeof(T).Equals(typeof(Meal)))
            {
                await page.Navigation.PushAsync(new NewMealPage());
                return;
            }
            
            if (typeof(T).Equals(typeof(Tuple<Dish, double>)))
            {
                await page.Navigation.PushAsync(new NewExistingPage<Dish>((ObservableCollection < Tuple<Dish, double> >)(object) collection));
                return;
            }

            throw new NotImplementedException();
        }

        public void Edit(ContentPage page)
        {

        }

        public void Delete()
        {

        }
    }
}