using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTasksListApp.SQLite
{
    [Table("Requests")]
    public class Request
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int IdRequest { get; set; }
        public int IdUser { get; set; }
        public string NameUser { get; set; }
        public int IdNewUser { get; set; }
        public string NameNewUser { get; set; }
        public string Message { get; set; }
        public bool IsReceived { get; set; }
    }
}
