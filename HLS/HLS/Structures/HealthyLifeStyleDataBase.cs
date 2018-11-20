using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Collections.Specialized;

namespace HLS.Structures
{
    public class HealthyLifeStyleDataBase : IEnumerable<BaseLifeUnit>
    {
        public const string filename = "BLF.db3";

        public IEnumerator<BaseLifeUnit> GetEnumerator()
        {
            return new BaseLifeUnitEnum(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public class BaseLifeUnitEnum : IEnumerator<BaseLifeUnit>
        {
            private HealthyLifeStyleDataBase _parent;
            private int _index = -1;
            private int _maxBufferSize = 16;
            private bool _disposedValue = false;

            protected int offset = 0;
            protected List<BaseLifeUnit> bufferList = new List<BaseLifeUnit>();

            public BaseLifeUnit lastBuffered = null;

            public BaseLifeUnitEnum(HealthyLifeStyleDataBase parent)
            {
                _parent = parent;
                RefreshBuffer();
            }

            public BaseLifeUnitEnum(HealthyLifeStyleDataBase parent, int customBufferSize)
            {
                _parent = parent;
                _maxBufferSize = customBufferSize;
                RefreshBuffer();
            }

            private void RefreshBuffer()
            {
                // TO DO
            }

            public BaseLifeUnit Current {
                get
                {
                    if (_parent == null || bufferList == null || _index != -1)
                    {
                        throw new InvalidOperationException();
                    }

                    return bufferList[_index];
                }
            }

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                Dispose(true);
                GC.SuppressFinalize(this);
            }

            protected virtual void Dispose(bool disposing)
            {
                if (!this._disposedValue)
                {
                    if (disposing)
                    {
                        bufferList = null;
                    }
                    _parent = null;
                }

                this._disposedValue = true;
            }

            public bool MoveNext()
            {
                _index++;
                if(_index == bufferList.Count)
                {
                    _index = 0;
                    offset += bufferList.Count;
                    RefreshBuffer();
                }
                return _index < bufferList.Count;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }

            ~BaseLifeUnitEnum()
            {
                Dispose(false);
            }
        }

        private SQLiteAsyncConnection database;

        public HealthyLifeStyleDataBase()
        {
            
        }
        
        public List<BaseLifeUnit> getAllBaseLifeUnit()
        {
            return Database.QueryAsync<BaseLifeUnit>("SELECT * " +
                "FROM [BaseLifeUnit] ORDER BY [Date] ASC, [ID] DESC " + $"LIMIT 1").Result;
        }

        private void openDatabase(string path)
        {
            database = new SQLiteAsyncConnection(path);
            database.CreateTableAsync<BaseLifeUnit>().Wait();
        }
        public SQLiteAsyncConnection Database
        {
            get
            {
                if (database == null)
                    openDatabase(DependencyService.Get<ISQLite>().GetDatabasePath(filename));
                 return database;
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
