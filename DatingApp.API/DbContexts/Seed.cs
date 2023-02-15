using DatingApp.API.Models;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text.Json.Serialization;

namespace DatingApp.API.DbContexts
{
    public class Seed
    {
        public static async void SeedUsers(ApplicationDbContext dbContext)
        {
            if (!dbContext.Users.Any())
            {
                var userData = System.IO.File.ReadAllText("DbContexts/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<User>>(userData);
                foreach (var user in users)
                {
                    byte[] passwordHash, passwordSalt;
                    CreatePasswordHash("password", out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.UserName = user.UserName.ToLower();

                    dbContext.Users.Add(user);
                }

                dbContext.SaveChanges();
            }
        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hash = new HMACSHA512())
            {
                passwordSalt = hash.Key;
                passwordHash = hash.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
