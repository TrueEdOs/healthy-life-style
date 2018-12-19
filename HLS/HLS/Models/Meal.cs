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
    public class Meal : INotifyPropertyChanged, IModel<Meal>, IDBPackable
    {
        [PrimaryKey]
        public string ID { get; set; } = Guid.NewGuid().ToString();

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
        public ObservableCollection<ExistingDish> Dishes { get; private set; } = new ObservableCollection<ExistingDish>();
        [Ignore]
        public bool Synced { get; set; } = false;
        [Ignore]
        public string Title => Name;
        [Ignore]
        public ObservableCollection<Meal> Collection => App.Database.MealsRepository.Collection;
        [Ignore]
        public ContentPage EditablePage => new NewMealPage(this);

        public Meal()
        {
                   
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void Serialize()
        {
            Properties = "SS$V000";
            foreach(var x in Dishes)
            {
                Properties += "$" + x.Dish.ID + "|" + x.Amount;
            }
            Properties += "$E-N-D";
        }

        public void Deserialize()
        {
            Dishes.Clear();
            Debug.Print("Properties " + Properties);
            
            if (Properties.Substring(0, 7) != "SS$V000")
                return;
           
            Properties = Properties.Substring(7, Properties.Length - 7);
            string id;
            double amount;
            
            while (Properties.IndexOf("$") != Properties.IndexOf("$E-N-D"))
            {
                //Debug.Print(Properties.Substring(1, Properties.IndexOf("|")));
                //return;
                id = Properties.Substring(1, Properties.IndexOf("|") - 1);
                
                Properties = Properties.Substring(Properties.IndexOf("|") + 1, Properties.Length - Properties.IndexOf("|")-1);
                amount = double.Parse(Properties.Substring(0, Properties.IndexOf("$")));

                Properties = Properties.Substring(Properties.IndexOf("$"), Properties.Length - Properties.IndexOf("$"));
                /*
                
                try
                {
                    App.Database.DishesRepository.Get(id);
                }catch(Exception e)
                {
                    Debug.Print("HAHA " + e.ToString());
                }

                
                return;*/
                Dishes.Add(new ExistingDish { Dish = App.Database.DishesRepository.Get(id), Amount = amount });
            }
        }
    }
}
