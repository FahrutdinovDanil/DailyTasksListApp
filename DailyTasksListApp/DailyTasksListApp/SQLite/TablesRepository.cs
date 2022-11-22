﻿using SQLite;
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
            database.CreateTable<Request>();
        }
        #region User
        public IEnumerable<User> GetUsers()
        {
            return database.Table<User>().ToList();
        }
        public User GetUser(int id)
        {
            return database.Get<User>(id);
        }
        public User GetUserId(int id)
        {
            return database.Table<User>().Where(a => a.Id == id).FirstOrDefault();
        }
        public IEnumerable<User> GetUsersId(int id)
        {
            return database.Table<User>().Where(a => a.Id != id);
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
        #endregion
        #region Task
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
        #endregion
        #region
        public IEnumerable<Request> GetRequests()
        {
            return database.Table<Request>().ToList();
        }
        public Request GetRequest(int id)
        {
            return database.Get<Request>(id);
        }
        //public IEnumerable<Request> GetRequestsId(int id)
        //{
        //    return database.Table<Request>().Where(a => a.IdUser == id);
        //}
        public Request GetRequestIdUser(int id)
        {
            return database.Table<Request>().Where(a => a.IdUser == id).FirstOrDefault();
        }
        public int DeleteRequest(int id)
        {
            return database.Delete<Request>(id);
        }
        public IEnumerable<Request> GetRequestUser(int id)
        {
            return database.Table<Request>().Where(a => a.IdUser == id);
        }
        public int SaveRequest(Request item)
        {
            if (item.IdRequest != 0)
            {
                database.Update(item);
                return item.IdRequest;
            }
            else
            {
                return database.Insert(item);
            }
        }
        #endregion
    }
}
