using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace HLS.Models
{
    public class User : IModel<User>, IDBPackable
    {
        [PrimaryKey]
        public string ID { get; set; } = Guid.NewGuid().ToString();

        public string Name { get; set; }    
        public string Properties { get; set; } = "";

        public string Title => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public ObservableCollection<User> Collection => throw new NotImplementedException();

        public ContentPage EditablePage => throw new NotImplementedException();

        public void Deserialize()
        {
            throw new NotImplementedException();
        }

        public void Serialize()
        {
            throw new NotImplementedException();
        }
    }
}
