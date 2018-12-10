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
            Type tt = typeof(T);
            if (tt.Equals(typeof(Meal)))
            {
                await page.Navigation.PushAsync(new NewMealPage());
            }
        }

        public void Edit(ContentPage page)
        {

        }

        public void Delete()
        {

        }
    }
}