﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTasksListApp.SQLite
{
    [Table("Tasks")]
    public class Task
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime DateTime { get; set; }

        public int IdUser { get; set; }
    }
}