using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;

namespace Exam2.Configuration
{
    class SQLiteHelper
    {
        private readonly string dbName = "t2004e.db";

        private static SQLiteHelper sQLiteHelper;

        public static SQLiteHelper GetInstance()
        {
            if (sQLiteHelper == null)
            {
                sQLiteHelper = new SQLiteHelper();
            }
            return sQLiteHelper;
        }

        private SQLiteHelper()
        {
            sQLiteConnection = new SQLiteConnection(dbName); // tao db;
            CreateUserTable();
        }

        public SQLiteConnection sQLiteConnection { get; private set; }

        public void CreateUserTable() // tao bang user
        {
            var sql_txt = @"CREATE TABLE IF NOT EXISTS 
                User(
                    id INT PRIMARY KEY, 
                    user_name NVARCHAR(200), 
                    password NVARCHAR(200)
                )";
            var statement = sQLiteConnection.Prepare(sql_txt);
            statement.Step();
        }
    }
}
