using System;
using System.Collections.Generic;
using System.Text;

namespace DailyTasksListApp
{
    public interface ISQLite
    {
        string GetDatabasePath(string filename);
    }
}
