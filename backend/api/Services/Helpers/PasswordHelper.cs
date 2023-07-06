using api.Data;
using api.Data.DTOs;
using Microsoft.EntityFrameworkCore;

namespace api.Services.Helpers
{
    public static class PasswordHelper
    {
        private static apiContext _context;



        public static void InitContext(apiContext context)
        {
            _context = context;
        }


        public static string HashPassword(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(10, 'a');

            return BCrypt.Net.BCrypt.HashPassword(password, salt);


        }




        public static async Task<bool> VerifyPassword(loginDTO login)
        {

            string storedHashedValue = await _context.users
                                          .Where(o => o.username == login.userName)
                                          .Select(o => o.passwordHash)
                                          .SingleAsync();
            bool isPasswordVerified = BCrypt.Net.BCrypt.Verify(login.password, storedHashedValue);


            return await Task.FromResult(isPasswordVerified);

        }

    }
}
