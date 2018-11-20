using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.CompilerServices;
using System.ComponentModel;
using SQLite;

namespace HLS.Structures
{
    public class BaseLifeUnit : INotifyPropertyChanged 
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; } = 0;

        public DateTime Date { get; set; } = DateTime.Now;
        public string Description { get; set; } = "";
        public int Callories { get; set; } = 0;
        public string Type { get; set; } = "";
        public string Properties { get; set; } = "";
        
        public string GetDateString()
        {
            return Date.ToString();
        }
        
        public override bool Equals(object obj)
        {
            return obj is BaseLifeUnit blf
                && Date == blf.Date
                && Description == blf.Description
                && ID == blf.ID
                && Type == blf.Type
                && Properties == blf.Properties;
        }

        public override int GetHashCode()
        {
            var hashCode = 666777;
            hashCode = hashCode * 666777 + ID.GetHashCode();
            hashCode = hashCode * 666777 + Date.GetHashCode();
            hashCode = hashCode * 666777 + Description.GetHashCode();
            hashCode = hashCode * 666777 + Type.GetHashCode();
            hashCode = hashCode * 666777 + Callories.GetHashCode();
            return hashCode;
        }

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            var changed = PropertyChanged;
            if(changed == null)
                return;
            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
