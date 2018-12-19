using HLS.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace HLS.Models
{
    public class Dish : IModel<Dish>, IDBPackable
    {
        [PrimaryKey]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public string Description { get; set; } = "";
        public string Name { get; set; } = "";
        public string Properties { get; set; } = "";
        public double CalloriesSpend { get; set; }
        public double ProteinsSpend { get; set; }
        public double CarbohydratesSpend { get; set; }
        public double FatsSpend { get; set; }

        [Ignore]
        public string Title => Name;
        [Ignore]
        public ObservableCollection<Dish> Collection => App.Database.DishesRepository.Collection;
        [Ignore]
        public ContentPage EditablePage => new NewDishPage(this);

        public void Deserialize()
        {
            // nothing to be done
        }

        public void Serialize()
        {
            // FOR THE FUTURE!!
        }
    }
}
