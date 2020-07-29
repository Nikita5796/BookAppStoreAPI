using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using BookApp.API.Entities;
using BookApp.API.Helpers;
using BookApp.API.Services;
using BookApp.BLL;
using BookApp.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserServiceBLL UserObj = new UserServiceBLL(new UserContext());

        private IUserService _userService;
        JWTHelper jwtHelper = new JWTHelper();
        //RefreshTokenHelper refToken = new RefreshTokenHelper();
        UserContext context = new UserContext();

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //login
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]User userParam)
        {
            var user = _userService.Authenticate(userParam.EmailId, userParam.Password); //authentication

            if (user != null)
            {
                user.Token = jwtHelper.Generate_Access_Token(user); //access token creation
                //var refreshToken = refToken.Generate_Refresh_Token(); //Refresh token creation

                //context.StoreRefreshToken(refreshToken,user.UserId,user.Token); //refresh token store in DB
            }

            return Ok(user);
        }



        //register
        [HttpPost("add")]
        public ActionResult<User> AddUser(User user)
        {
            UserObj.AddUser(user);

            return Ok();
        }

        //[HttpGet]
        //public ActionResult<IList<User>> GetUsers()
        //{
        //    return UserObj.GetUsers();
        //}
    }
}