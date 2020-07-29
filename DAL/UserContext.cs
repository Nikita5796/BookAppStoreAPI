using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BookApp.API.Entities;

namespace BookApp.DAL
{
    public class UserContext : IUser
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader reader;
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();

        public UserContext()
        {
            conn = new SqlConnection("data source=NIKITAT-MSD2\\SQLEXPRESS2014; initial catalog=BookAppDB; integrated security=true");
        }

        public bool AddUser(User user)
        {
            bool status = false;
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "AddUser";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@UserId", user.UserId);
                cmd.Parameters.AddWithValue("@Name", user.UserName);
                cmd.Parameters.AddWithValue("@EmailId", user.EmailId);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@Contact", user.Contact);
                cmd.Parameters.AddWithValue("@Gender", user.Gender);
                cmd.Parameters.AddWithValue("@Address", user.Address);
                cmd.Parameters.AddWithValue("@StateId", user.StateId);
                cmd.Parameters.AddWithValue("@CityId", user.CityId);
                cmd.Parameters.AddWithValue("@PostalCode", user.PostalCode);

                conn.Open();

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                    status = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
            return status;
        }

        public User UserLogin(string emailId, string password)
        {
            User user = null;
            try
            {
                
                //cmd.CommandText = "UserLogin";
                cmd = new SqlCommand("UserLogin", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmailId", emailId);
                cmd.Parameters.AddWithValue("@Password", password);
                adapter.SelectCommand = cmd;
                adapter.Fill(ds,"users");
                adapter.Dispose();
                cmd.Dispose();
                conn.Close();
                dt = ds.Tables[0];

                user = new User
                {
                    UserId = Convert.ToInt32(dt.Rows[0]["UserId"]),
                    UserName = dt.Rows[0]["Name"].ToString(),
                    EmailId = dt.Rows[0]["EmailId"].ToString(),
                    Password = dt.Rows[0]["Password"].ToString(),
                    Contact = Convert.ToInt64(dt.Rows[0]["Contact"]),
                    Gender = dt.Rows[0]["Gender"].ToString(),
                    Address = dt.Rows[0]["Address"].ToString(),
                    StateId = Convert.ToInt32(dt.Rows[0]["StateId"]),
                    CityId = Convert.ToInt32(dt.Rows[0]["CityId"]),
                    PostalCode = Convert.ToInt32(dt.Rows[0]["PostalCode"]),
                    Token = dt.Rows[0]["Token"].ToString(),
                    RefreshToken = dt.Rows[0]["RefreshToken"].ToString()
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return user;
        }

        public List<User> GetUsers()
        {
            List<User> list = null;
            try
            {
                cmd = new SqlCommand("usp_Get_Users", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                conn.Open();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds, "users");
                adapter.Dispose();
                cmd.Dispose();
                conn.Close();
                dt = ds.Tables[0];

                User user = new User
                {
                    UserId = Convert.ToInt32(dt.Rows[0]["UserId"]),
                    UserName = dt.Rows[0]["Name"].ToString(),
                    EmailId = dt.Rows[0]["EmailId"].ToString(),
                    Password = dt.Rows[0]["Password"].ToString(),
                    Contact = Convert.ToInt64(dt.Rows[0]["Contact"]),
                    Gender = dt.Rows[0]["Gender"].ToString(),
                    Address = dt.Rows[0]["Address"].ToString(),
                    StateId = Convert.ToInt32(dt.Rows[0]["StateId"]),
                    CityId = Convert.ToInt32(dt.Rows[0]["CityId"]),
                    PostalCode = Convert.ToInt32(dt.Rows[0]["PostalCode"]),
                    Token = dt.Rows[0]["Token"].ToString(),
                    RefreshToken = dt.Rows[0]["RefreshToken"].ToString()
                };

                list.Add(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in reading...." + list.Count);
                throw ex;
            }
            return list;
        }

        public void StoreRefreshToken(RefreshToken refToken, int userId,string jwtToken)
        {
            try
            {
                cmd = conn.CreateCommand();
                cmd.CommandText = "usp_Store_Refresh_Token";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TokenId", refToken.TokenId);
                cmd.Parameters.AddWithValue("@UserId", userId);
                cmd.Parameters.AddWithValue("@Token", refToken.Token);
                cmd.Parameters.AddWithValue("@ExpiryDate", refToken.ExpiryDate);
                cmd.Parameters.AddWithValue("@JwtToken", jwtToken);

                conn.Open();

                int count = cmd.ExecuteNonQuery();
                if (count > 0)
                    Console.WriteLine("data added...." + count);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
