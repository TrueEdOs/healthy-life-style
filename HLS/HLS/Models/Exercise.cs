using HLS.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace HLS.Models
{
    public class Exercise : IModel<Exercise>, IDBPackable
    {
        [PrimaryKey]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public string Description { get; set; } = "";
        public string Name { get; set; } = "";
        public string Properties { get; set; } = "";
        public double CaloriesSpend { get; set; }

        public string Title => Name;

        public ObservableCollection<Exercise> Collection => App.Database.ExercisesRepository.Collection;

        public ContentPage EditablePage => new NewExercisePage(this);

        public void Deserialize()
        {
            //HA HA
        }

        public void Serialize()
        {
            //HO HO
        }
    }
}
