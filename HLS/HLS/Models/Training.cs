using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace HLS.Models
{
    public class Training : INotifyPropertyChanged
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public string Name { get; set; } = "";
        public string Properties { get; set; } = "";

        [Ignore]
        public double Calories { get; private set; }
        [Ignore]
        public ObservableCollection<Tuple<Exercise, double> > Exercises { get; private set; }
        [Ignore]
        public bool Synced { get; set; } = false;


        public Training()
        {
            Synced = true;
        }

        public Training(bool synced)
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
