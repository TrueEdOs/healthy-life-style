using HLS.Droid;
using Xamarin.Forms;
using System.IO;
using System;

[assembly: Dependency(typeof(SQLite_Android))]
namespace HLS.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}