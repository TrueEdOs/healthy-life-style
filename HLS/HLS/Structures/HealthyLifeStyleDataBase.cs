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
        private readonly string filename;
        private readonly ObservableCollection<Meal> meals = new ObservableCollection<Meal>();
        private readonly ObservableCollection<Training> trainings = new ObservableCollection<Training>();
        private readonly ObservableCollection<Dish> dishes = new ObservableCollection<Dish>();
        private readonly ObservableCollection<Exercise> exercises = new ObservableCollection<Exercise>();
        private readonly Repository<Meal> mealsRepository;
        private readonly Repository<Dish> dishesRepository;
        private readonly Repository<Training> trainingsRepository;
        private readonly Repository<Exercise> exerciseRepository;

        private SQLiteAsyncConnection database = null;

        public HealthyLifeStyleDataBase(string filename)
        {
            this.filename = filename;
           
            LoadEntities();
            dishesRepository = new Repository<Dish>(Database, dishes);
            mealsRepository = new Repository<Meal>(Database, meals);

            exerciseRepository = new Repository<Exercise>(Database, exercises);
            trainingsRepository = new Repository<Training>(Database, trainings);
            DeserializeEntities();
        }

        private void LoadEntities()
        {
            Debug.Print("SIGN24 " + Database.Table<Meal>().ToListAsync().Result.Count.ToString());
            foreach (var x in Database.Table<Meal>().ToListAsync().Result)
                meals.Add(x);
            foreach (var x in Database.Table<Dish>().ToListAsync().Result)
                dishes.Add(x);
            foreach (var x in Database.Table<Training>().ToListAsync().Result)
                trainings.Add(x);
            foreach (var x in Database.Table<Exercise>().ToListAsync().Result)
                exercises.Add(x);
        }

        private async void DeserializeEntities()
        {
            await Task.Run( ()=> mealsRepository.DeserializeAll());
            await Task.Run( () => trainingsRepository.DeserializeAll());
        }

        private void OpenDatabase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            try
            {
                database.CreateTableAsync<Meal>().Wait();
                database.CreateTableAsync<Training>().Wait();
                database.CreateTableAsync<Dish>().Wait();
                database.CreateTableAsync<Exercise>().Wait();
            }
            catch(Exception e)
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
                        OpenDatabase(DependencyService.Get<ISQLite>().GetDatabasePath(filename));
                    }
                }catch(Exception e)
                {
                    Debug.Print("SIGN3 " + e);
                }
                
                return database;
            }
        }

        public Repository<Exercise> ExercisesRepository => exerciseRepository;

        public Repository<Training> TrainingsRepository => trainingsRepository;

        public Repository<Dish> DishesRepository => dishesRepository;

        public Repository<Meal> MealsRepository => mealsRepository;
    }
}
