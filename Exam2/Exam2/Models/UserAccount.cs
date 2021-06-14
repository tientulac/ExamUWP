using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2.Models
{
    class UserAccount
    {
        public UserAccount(int id, string user_name, string password)
        {
            this.id = id;
            this.user_name = user_name;
            this.password = password;
        }
        public int id { get; set; }
        public string user_name { get; set; }
        public string password { get; set; }

    }
}
