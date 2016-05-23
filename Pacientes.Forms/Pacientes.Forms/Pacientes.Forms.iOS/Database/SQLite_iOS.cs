using System;
using Pacientes.Forms.Droid;
using System.IO;
using Pacientes.Forms.Interfaces;
using Pacientes.Forms.Droid.Database;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_iOS))]

namespace Pacientes.Forms.Droid.Database
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS()
        {
        }

        #region ISQLite implementation

        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "database.db3";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }

        #endregion

    }
}