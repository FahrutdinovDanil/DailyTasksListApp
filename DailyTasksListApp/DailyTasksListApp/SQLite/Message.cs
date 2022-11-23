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
        public string Discription { get; set; }
        public DateTime DateTime { get; set; }
        public int IdUser { get; set; }
        public int IdNewUser { get; set; }
    }
}
