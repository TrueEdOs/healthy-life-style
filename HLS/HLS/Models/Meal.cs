using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace HLS.Models
{
    public class Meal : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public string Name { get; set; } = "";
        public string Properties { get; set; } = "";

        [Ignore]
        public double Proteins { get; private set; }
        [Ignore]
        public double Fats { get; private set; }
        [Ignore]
        public double Carbohydrates { get; private set; }
        [Ignore]
        public double Calories { get; set; }
        [Ignore]
        public ObservableCollection<Tuple<Dish, double>> Dishes { get; private set; } = new ObservableCollection<Tuple<Dish, double>>();
        [Ignore]
        public bool Synced { get; set; } = false;

        public Meal()
        {
            Synced = true;
        }

        public Meal(bool synced)
        {
            Synced = synced;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Serialize()
        {
            throw new NotImplementedException();
        }

        public void Deserialize()
        {
            throw new NotImplementedException();
        }
    }
}
