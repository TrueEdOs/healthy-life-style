using HLS.Models;
using HLS.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace HLS.Views
{
    public class BasicListPage<T> : ContentPage where T : IModel<T>
    {
        private BasicListViewModel<T> viewModel;
        
        public BasicListPage(ObservableCollection<T> collection, App.CreatePage createPage)
        {
            viewModel = new BasicListViewModel<T>(collection, createPage);
            BindingContext = viewModel;

            ListView list = new ListView
            {
                ItemsSource = viewModel.RepresentationCollection,
                IsPullToRefreshEnabled = false,
                ItemTemplate = new DataTemplate(() =>
                {
                    Label titleLabel = new Label { FontSize = 18 };
                    titleLabel.SetBinding(Label.TextProperty, "Title");

                    Label descriptionLabel = new Label();
                    descriptionLabel.SetBinding(Label.TextProperty, "Description");

                    return new ViewCell
                    {
                        View = new StackLayout
                        {
                            Padding = new Thickness(0, 5),
                            Orientation = StackOrientation.Vertical,
                            Children = { titleLabel, descriptionLabel }
                        }
                    };
                })

            };

            list.ItemSelected += (sender, e) =>
            {
                viewModel.selectedItem = (T)e.SelectedItem;
            };

            Content = new StackLayout
            {
                Children = {
                    list
                }
            };


            ToolbarItems.Add(new ToolbarItem("", "addIcon.xml", () =>
            { viewModel.Add(this); }));

            ToolbarItems.Add(new ToolbarItem("", "checkIcon.xml", () =>
            { if(list.SelectedItem != null) viewModel.Edit(this); }));

            ToolbarItems.Add(new ToolbarItem("", "deleteIcon.xml", () =>
            { if(list.SelectedItem != null) viewModel.Delete(); }));
        }
    }
}