using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTasksListApp.SQLite
{
    [Table("Products")]
    public class Product
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public int Count { get; set; }
        public string CountType { get; set; }
        public int IdUser { get; set; }
    }
}
