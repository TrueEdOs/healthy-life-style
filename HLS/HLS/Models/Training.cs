using HLS.Views;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace HLS.Models
{
    public class Training : INotifyPropertyChanged, IModel<Training>, IDBPackable
    {
        [PrimaryKey]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; } = "";
        public string Type { get; set; } = "";
        public string Name { get; set; } = "";
        public string Properties { get; set; } = "";

        [Ignore]
        public double Calories { get; private set; }
        [Ignore]
        public ObservableCollection<ExistingExercise> Exercises { get; private set; } = new ObservableCollection<ExistingExercise>();
        [Ignore]
        public bool Synced { get; set; } = false;
        [Ignore]
        public string Title => Name;
        [Ignore]
        public ObservableCollection<Training> Collection => App.Database.TrainingsRepository.Collection;
        [Ignore]
        public ContentPage EditablePage => new NewTrainingPage(this);

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
            Properties = "SS$V000";
            foreach (var x in Exercises)
            {
                Properties += "$" + x.Exercise.ID + "|" + x.Count;
            }
            Properties += "$E-N-D";
        }

        public void Deserialize()
        {
            Exercises.Clear();
            Debug.Print("Properties " + Properties);

            if (Properties.Substring(0, 7) != "SS$V000")
                return;

            Properties = Properties.Substring(7, Properties.Length - 7);
            string id;
            double count;

            while (Properties.IndexOf("$") != Properties.IndexOf("$E-N-D"))
            {
                id = Properties.Substring(1, Properties.IndexOf("|") - 1);

                Properties = Properties.Substring(Properties.IndexOf("|") + 1, Properties.Length - Properties.IndexOf("|") - 1);
                count = double.Parse(Properties.Substring(0, Properties.IndexOf("$")));

                Properties = Properties.Substring(Properties.IndexOf("$"), Properties.Length - Properties.IndexOf("$"));

                Exercises.Add(new ExistingExercise { Exercise = App.Database.ExercisesRepository.Get(id), Count = count });
            }
        }
    }
}
