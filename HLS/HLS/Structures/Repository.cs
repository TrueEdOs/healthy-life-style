using HLS.Models;
using SQLite;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;

namespace HLS.Structures
{
    public class Repository<T> : IEnumerable<T> where T : IDBPackable
    {
        private readonly ObservableCollection<T> collection;
        private SQLiteAsyncConnection database;
        private readonly Dictionary<string, T> map;

        public Repository(ObservableCollection<T> collection) : this(null, collection)
        {
            Debug.Print("Warning! Creating repository without database assign!");
        }

        public Repository(SQLiteAsyncConnection database) : this(database, new ObservableCollection<T>())
        {
            Debug.Print("The entities from database WILL NOT BE LOADED! Generating new collection...");
        }

        public Repository(SQLiteAsyncConnection database, ObservableCollection<T> collection)
        {
            this.collection = collection;
            this.database = database;
            map = new Dictionary<string, T>();
            Debug.Print("SIGN22 " + collection.Count.ToString());
            foreach (var x in collection)
            {
                map.Add(x.ID, x);
            }
            
            
            collection.CollectionChanged += CollectionChanged;
        }

        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Debug.Print("Depecated methods using detected!!");
            if(e.OldItems != null)
                foreach (var x in e.OldItems)
                {
                    if (map.ContainsKey(((T)x).ID))
                    {
                        Remove((T)x);
                    }
                }

            if(e.NewItems != null)
                foreach (var x in e.NewItems)
                {
                    if (!map.ContainsKey(((T)x).ID))
                    {
                        Add((T)x);
                    }
                }
        }

        public void DeserializeAll()
        {
            foreach (var x in collection)
                x.Deserialize();
        }

        public async void AddOrUpdate(T element)
        {
            if (map.ContainsKey(element.ID))
                Update(element);
            else
                Add(element);
        }

        public T Get(string id)
        {
            if (!map.ContainsKey(id))
            {
                Debug.Print(map.Count.ToString());
                throw new Exception();
            }
            return map[id];
        }

       
        public void Add(T element)
        {
            element.Serialize();
            map.Add(element.ID, element);
            collection.Add(element);

            if (database != null)
                database.InsertAsync(element);
        }

        public void Update(T element)
        {
            element.Serialize();
            if (database != null)
                database.UpdateAsync(element);
        }

        public void Remove(T element)
        {
            map.Remove(element.ID);
            collection.Remove(element);
            if (database != null)
                database.DeleteAsync(element);
        }

        public void Clear()
        {
            while (Collection.Count > 0)
                Collection.RemoveAt(Collection.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return collection.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public ObservableCollection<T> Collection => collection;
    }
}
