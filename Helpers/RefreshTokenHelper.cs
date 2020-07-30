using BookApp.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace BookAppStoreAPI.Helpers
{
    public class RefreshTokenHelper
    {
        public RefreshToken Generate_Refresh_Token()
        {
            RefreshToken refToken = new RefreshToken();

            var randomNumber = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomNumber);
                refToken.Token = Convert.ToBase64String(randomNumber);
            }
            refToken.ExpiryDate = DateTime.UtcNow.AddMinutes(20);

            return refToken;
        }
    }
}
