using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using TodoApp.Models;
using TodoApp.Helpers;
using System;

namespace TodoApp.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        Task<IEnumerable<User>> GetAll();

    }

    public class UserService : IUserService
    {
        private readonly TodoContext _context;
        public UserService(TodoContext context)
        {
            _context = context;
        }
        public async Task<User> Authenticate(string username, string password)
        {
            try
            {
                Console.WriteLine(username);
                Console.WriteLine(password);
                var user = await Task.Run(() => _context.Users.Where(u => u.Username == username).Single());

                if (user == null)
                    return null;

                user.Password = null;
                //Console.WriteLine(user.Password);
                return user;
            }
            catch
            {
                return null;
            }



        }

        public async Task<IEnumerable<User>> GetAll()
        {
            return await Task.Run(() => _context.Users.ToList());
        }
    }
}