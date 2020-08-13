using BookApp.API.Entities;
using BookAppStoreAPI.Entities;
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
        List<User> GetUsers();
        List<City> GetCities();
        List<State> GetStates();
    }
}
