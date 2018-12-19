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
    class BasicListViewModel<T> where T : IModel<T>
    {
        public ObservableCollection<T> collection;
        public T selectedItem;
        public bool selected = false;
        public ObservableCollection<T> RepresentationCollection => collection;
        public App.CreatePage createPage;

        public BasicListViewModel(ObservableCollection<T> collection, App.CreatePage createPage)
        {
            this.collection = collection;
            this.createPage = createPage;
        }

        public async void Add(ContentPage page)
        {
            await page.Navigation.PushAsync(createPage.Invoke());
        }

        public async void Edit(ContentPage page)
        {
            if (selectedItem == null)
            {
                // TO DO
                return;
            }

            await page.Navigation.PushAsync(selectedItem.EditablePage);
        }

        public void Delete()
        {
            if (selectedItem == null)
            {
                // TO DO
                return;
            }

            collection.Remove(selectedItem);
        }
    }
}