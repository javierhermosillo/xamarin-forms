using System;
using Pacientes.Forms.Droid;
using System.IO;
using Pacientes.Forms.Interfaces;
using Pacientes.Forms.Droid.Database;
using Xamarin.Forms;
using Android.Content.Res;

[assembly: Dependency(typeof(SQLite_Android))]

namespace Pacientes.Forms.Droid.Database
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android()
        {
        }

        #region ISQLite implementation

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "database.db3";
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal); // Documents folder
            var path = Path.Combine(documentsPath, sqliteFilename);

            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }

        #endregion

    }
}