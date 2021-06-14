using Exam2.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLitePCL;
using Exam2.Configuration;

namespace Exam2.Models
{
    class User : UserService
    {
        public bool Register(UserAccount account)
        {
            SQLiteHelper qLiteHelper = SQLiteHelper.GetInstance();
            SQLiteConnection sQLiteConnection = qLiteHelper.sQLiteConnection;
            string sql_txt = "insert into User (id,user_name,password) values(?,?,?)";
            var statement = sQLiteConnection.Prepare(sql_txt);
            statement.Bind(1, account.id);
            statement.Bind(2, account.user_name);
            statement.Bind(3, account.password);
            var rs = statement.Step();
            return rs == SQLiteResult.OK;
        }

        public List<UserAccount> GetUser()
        {
            SQLiteHelper qLiteHelper = SQLiteHelper.GetInstance();
            SQLiteConnection sQLiteConnection = qLiteHelper.sQLiteConnection;
            string sql_txt = "SELECT * FROM User";
            var statement = sQLiteConnection.Prepare(sql_txt);
            List<UserAccount> list = new List<UserAccount>();
            while (SQLiteResult.ROW == statement.Step())
            {
                int id = Convert.ToInt32(statement[0]);
                string user_name = (string)statement[1];
                string password = (string)statement[2];
                UserAccount u = new UserAccount(id, user_name, password);
                list.Add(u);
            }
            return list;
        }
    }
}
