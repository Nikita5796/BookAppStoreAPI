using BookApp.API.Entities;
using BookApp.API.Helpers;
using BookApp.BLL;
using BookApp.DAL;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.API.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);
    }

    public class UserService : IUserService
    {
        private static UserServiceBLL UserObj = new UserServiceBLL(new UserContext());

        public User Authenticate(string email, string password)
        {
            UserContext context = new UserContext();

            User user = context.UserLogin(email, password);

            if (user != null)
            {
                Console.WriteLine("Valid");
            }
            else
            {
                Console.WriteLine("Invalid Credentials.");
            }
            return user;
        }

            //bool status = context.UserLogin(email, password);
       

            //return null if user not found
            //if (user == null)
            //    return null;

            //// authentication successful so generate jwt token
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Subject = new ClaimsIdentity(new Claim[]
            //    {
            //        new Claim(ClaimTypes.Name, user.UserId.ToString())
            //    }),
            //    Expires = DateTime.UtcNow.AddDays(7),
            //    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            //};
            //var token = tokenHandler.CreateToken(tokenDescriptor);
            //user.Token = tokenHandler.WriteToken(token);

            ////refresh token generation
            //user.RefreshToken = Generate_Refresh_Token().Token;

            //user.Password = null;

            //return user;
        }

        //public IEnumerable<User> GetAll()
        //{
        //    // return users without passwords
        //    return _users.Select(x => {
        //        x.Password = null;
        //        return x;
        //    });
        //}

        //private RefreshToken Generate_Refresh_Token()
        //{
        //    RefreshToken refToken = new RefreshToken();

        //    var randomNumber = new byte[32];
        //    using (var rng = RandomNumberGenerator.Create())
        //    {
        //        rng.GetBytes(randomNumber);
        //        refToken.Token = Convert.ToBase64String(randomNumber);
        //    }
        //    refToken.ExpiryDate = DateTime.UtcNow.AddMonths(1);

        //    return refToken;
        //}
}
