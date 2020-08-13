using BookApp.API.Entities;
using BookApp.DAL;
using BookAppStoreAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.BLL
{
    public class UserServiceBLL
    {
        IUser userDAL;

        public UserServiceBLL(IUser userDAL)
        {
            this.userDAL = userDAL;
        }

        public bool AddUser(User user)
        {
            bool status = false;

            try
            {
                status = userDAL.AddUser(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return status;
        }

        public List<User> GetUsers()
        {
            List<User> users = null;
            try
            {
                users = userDAL.GetUsers();
                return users;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public List<City> GetCities()
        {
            List<City> citylist = new List<City>();
            try
            {
                citylist = userDAL.GetCities();
                return citylist;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<State> GetStates()
        {
            List<State> statelist = new List<State>();
            try
            {
                statelist = userDAL.GetStates();
                return statelist;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
