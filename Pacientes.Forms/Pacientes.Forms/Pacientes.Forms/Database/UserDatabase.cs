using Pacientes.Forms.Entities;
using Pacientes.Forms.Interfaces;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Pacientes.Forms.Database
{
    public class UserDatabase
    {
        private static object locker = new object();

        private SQLiteConnection database;

        public UserDatabase()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<User>();
        }

        public IEnumerable<User> GetUsers()
        {
            lock (locker)
            {
                return (from i in database.Table<User>() select i).ToList();
            }
        }

        public User GetUser(string username)
        {
            lock (locker)
            {
                return database.Table<User>().FirstOrDefault(x => x.Username == username);
            }
        }

        public int SaveUser(User user)
        {
            User t = GetUser(user.Username);

            lock (locker)
            {
                if (t == null)
                {
                    return database.Insert(user);
                }
                else
                {
                    t.Password = user.Password;                
                    database.Update(t);
                    return t.ID;
                }
            }   
        }

        public List<User> ValidateUser(string username, string password)
        {
            lock (locker)
            {
                return database.Query<User>(string.Format("SELECT * FROM [User] WHERE [Username] = '{0}' AND [Password] = '{1}'", username, password));
            }
        }
    }
}