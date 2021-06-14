using Exam2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam2.Services
{
    interface UserService
    {
        List<UserAccount> GetUser();
        bool Register(UserAccount account);
    }
}
