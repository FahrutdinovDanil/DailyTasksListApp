using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTasksListApp.SQLite
{
    [Table("Messages")]
    public class Message
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string NewUserName { get; set; }
        public string NewUserSurname { get; set; }
        public bool IsDate { get; set; }
        public bool IsDone { get; set; }
        public string Status { get; set; }
        public string Discription { get; set; }
        public DateTime DateTime { get; set; }
        public int IdUser { get; set; }
        public int IdNewUser { get; set; }
    }
}
