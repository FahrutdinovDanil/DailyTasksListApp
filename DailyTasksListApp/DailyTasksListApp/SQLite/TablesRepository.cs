using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTasksListApp.SQLite
{
    public class TablesRepository
    {
        SQLiteConnection database;
        public TablesRepository(string databasePath)
        {
            database = new SQLiteConnection(databasePath);
            database.CreateTable<User>();
            database.CreateTable<Task>();
        }

        public IEnumerable<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }
        public User GetUser(int id)
        {
            return database.Get<User>(id);
        }
        public int DeleteUser(int id)
        {
            return database.Delete<User>(id);
        }
        public int SaveUser(User item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }

        public IEnumerable<Task> GetTasks()
        {
            return database.Table<Task>().ToList();
        }
        public IEnumerable<Task> GetTasksId(int id)
        {
            return database.Table<Task>().Where(a => a.IdUser == id);
        }
        public Task GetTask(int id)
        {
            return database.Get<Task>(id);
        }
        public int DeleteTask(int id)
        {
            return database.Delete<Task>(id);
        }
        public int SaveTask(Task item)
        {
            if (item.Id != 0)
            {
                database.Update(item);
                return item.Id;
            }
            else
            {
                return database.Insert(item);
            }
        }
    }
}
