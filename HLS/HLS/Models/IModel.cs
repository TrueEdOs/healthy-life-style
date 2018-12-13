using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace HLS.Models
{
    public interface IModel<T>
    {
        string Title { get; }
        string Description { get; }
        ObservableCollection<T> Collection { get; set; }
        ContentPage EditablePage { get; }
    }
}
