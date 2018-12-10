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
    public class BasicListPage<T> : ContentPage
    {
        private BasicListViewModel<T> viewModel;
        public BasicListPage(ObservableCollection<T> collection)
        {
            viewModel = new BasicListViewModel<T>(collection);
            BindingContext = viewModel;
            ToolbarItems.Add(new ToolbarItem("", "addIcon.xml", () =>
            { viewModel.Add(this); }));

            ToolbarItems.Add(new ToolbarItem("", "checkIcon.xml", () =>
            { viewModel.Edit(this); }));

            ToolbarItems.Add(new ToolbarItem("", "deleteIcon.xml", () =>
            { viewModel.Delete(); }));

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
                viewModel.selectedItem = (BasicRepresentationModel)e.SelectedItem;
            };

            Content = new StackLayout
            {
                Children = {
                    list
                }
            };
        }
    }
}