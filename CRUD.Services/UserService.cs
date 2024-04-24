using CRUD.Data;
using CRUD.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services
{
    public class UserService
    {
        private readonly MyDbContext context;
        public UserService(MyDbContext myDbContext) {
            this.context = myDbContext;
        }
        public async Task<string> AddUser(User user)
        {
            try
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                return "User Added!";
            }
            catch (Exception ex)
            {
                return "Failed to add User " + ex.Message;
            }
        }

        public async Task<string> Login(string email, string password)
        {
            if(email == null || password == null)
            {
                return "Please enter Email and Password";
            }
            var authenticatedUser = await context.Users.FirstOrDefaultAsync(u => u.EmailAddress == email &&  u.Password == password);
            if (authenticatedUser == null)
            {
                return "Invalid Email or Password";
            }

            return "Login successfull";
        }
    }
}
