using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTasksListApp.SQLite
{
    [Table("Friends")]
    public class Friend
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public int IdUser { get; set; }
        public int IdNewUser { get; set; }
    }
}
