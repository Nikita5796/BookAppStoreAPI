using BookApp.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DAL
{
    public interface IUser
    {
        bool AddUser(User user);
        //bool UserLogin(string emailId, string password);
        List<User> GetUsers();
    }
}
