using BLL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService : IUser
    {
        private readonly ProjectManagementDbContext Db;

        public UserService(ProjectManagementDbContext Db)
        {
            this.Db = Db;
        }

        public int Add(User model)
        {
            int Result = -1;
            try
            {
                model.Username = model.Username.Trim();
                var existName = Db.Users.FirstOrDefault(u => u.Username.Trim() == model.Username.Trim());
                if (existName != null)
                {
                    return -3;
                }
                string hashedPassword = HashPassword(model.Password);
                model.Password = hashedPassword;

                Db.Users.Add(model);
                Result = Db.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding user: {ex.Message}");
            }
            return Result;
        }

        private static string HashPassword(string password)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public List<User> GetUsers()
        {
            try
            {
                return Db.Users.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error getting users: {ex.Message}");
                return new List<User>();
            }
        }

        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            try
            {
                var user = await Db.Users.FirstOrDefaultAsync(u => u.Username.Trim() == username.Trim());

                if (user != null && VerifyHashedPassword(user.Password, password))
                {
                    return user;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving user: {ex.Message}");
                return null;
            }
        }

        public static bool VerifyHashedPassword(string hashedPassword, string providedPassword)
        {
            var providedPasswordHash = HashPassword(providedPassword);
            return string.Equals(hashedPassword, providedPasswordHash);
        }
    }
}
