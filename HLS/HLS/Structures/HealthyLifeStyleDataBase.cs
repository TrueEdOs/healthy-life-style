using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Diagnostics;
using HLS.Models;

namespace HLS.Structures
{
    public class HealthyLifeStyleDataBase
    {
        private string filename;
        private readonly ObservableCollection<Meal> meals = new ObservableCollection<Meal>();
        private SQLiteAsyncConnection database = null;

        private void LoadMeals()
        {
            foreach(var meal in getAllBaseLifeUnit())
                if(meal.Type == "meal")
                    meals.Add(new Meal(true));
        }

        private void SyncMeals()
        {
            foreach (var meal in meals)
            {

                if (!meal.Synced)
                {
                    Debug.Print("SING5 ");
                    //Database.InsertAsync(meal.Serealize()).Wait();
                }
                else
                    Debug.Print("SIGN6 ");
            }
            /*if(getAllBaseLifeUnit().Count != meals.Count)
            {
                throw new Exception();
            }*/
        }
        private void MealsUpdated(object sender, NotifyCollectionChangedEventArgs e)
        {
            SyncMeals();
        }

        public HealthyLifeStyleDataBase(string filename)
        {
            this.filename = filename;
            LoadMeals();
            meals.CollectionChanged += MealsUpdated;
        }

        

        private List<BaseLifeUnit> getAllBaseLifeUnit()
        {
                return Database.Table<BaseLifeUnit>().ToListAsync().Result;
        }

        private void OpenDatabase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            try
            {
                database.CreateTableAsync<BaseLifeUnit>().Wait();
            }catch(Exception e)
            {
                Debug.Print("SIGN4 " + e);
            }
        }

        public SQLiteAsyncConnection Database
        {
            get
            {
                try
                {
                    if (database == null)
                    {
                        Debug.Print("SIGN1 -> " + DependencyService.Get<ISQLite>().GetDatabasePath(filename));
                        OpenDatabase(DependencyService.Get<ISQLite>().GetDatabasePath(filename));
                        Debug.Print("SIGN2 -> " + DependencyService.Get<ISQLite>().GetDatabasePath(filename));
                    }
                }catch(Exception e)
                {
                    Debug.Print("SIGN3 " + e);
                }
                 return database;
            }
        }

        public ObservableCollection<Meal> Meals
        {
            get
            {
                return meals;
            }
        }
        public async Task RemoveAsync(BaseLifeUnit blf)
        {
            await Database.DeleteAsync(blf);
            //CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, blf));
        }

        public async Task AddAsync(BaseLifeUnit blf)
        {
            if(blf.ID != 0)
                await Database.UpdateAsync(blf);
            else
                await Database.InsertAsync(blf);
            //CollectionChanged(this, new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, blf));
        }

        public void Add(BaseLifeUnit blf)
        {
            Task.Run(() => AddAsync(blf)).GetAwaiter().GetResult();
        }
    }
}
