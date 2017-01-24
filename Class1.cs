using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    class Database
    {
        string path;
        public SQLite.Net.SQLiteConnection conn;
        static Database instance;
        public Database()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "db.sqlite");
            conn = new SQLite.Net.SQLiteConnection(new
                SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
            conn.CreateTable<Task>();
        }

        static public Database getInstance()
        {
            if (instance == null)
                instance = new Database();
            return instance;
        }
    }

    class TaskModel
    {
        static public void update(Task task)
        {
            Database.getInstance().conn.Update(task);
        }
        static public void add(Task task)
        {
            Database.getInstance().conn.Insert(task);
        }

        static public void removeById(int id)
        {
            Database.getInstance().conn.Execute("DELETE FROM Task WHERE id = ?", id);
        }

        static public List<Task> findAll()
        {
            List<Task> tasks = new List<Task>();
            tasks = (from t in Database.getInstance().conn.Table<Task>()
                     orderby t.dueDate ascending
                     select t).ToList();
            return tasks;
        }

        static public List<Task> findAllDone()
        {
            List<Task> tasks = new List<Task>();
            tasks = (from t in Database.getInstance().conn.Table<Task>()
                     orderby t.dueDate ascending
                     where t.completed == true
                     select t).ToList();
            return tasks;
        }

        static public List<Task> findAllNotDone()
        {
            List<Task> tasks = new List<Task>();
            tasks = (from t in Database.getInstance().conn.Table<Task>()
                     orderby t.dueDate ascending
                     where t.completed == false
                     select t).ToList();
            return tasks;
        }


        static public Task findById(int id)
        {
            Task task = new ToDoList.Task();
            task = (from t in Database.getInstance().conn.Table<Task>()
                    where t.id == id
                    select t).FirstOrDefault();
            return task;
        }
    }

    class Task
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public string name { get; set; }
        public string content { get; set; }
        public DateTime dueDate { get; set; }
        public bool? completed { get; set; }
        
        public Task()
        {
            this.completed = false;
        }

        public Task(string name, string content, DateTime date)
        {
            this.name = name;
            this.content = content;
            this.dueDate = date;
            this.completed = false;
        }
    }
}
