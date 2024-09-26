using Microsoft.EntityFrameworkCore;
using Project_EF_Core.Data;
using Project_EF_Core.Interfaces;
using Project_EF_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_EF_Core.Repository
{
    public class UserRepository : IUser
    {
        public async Task AddUserAsync(User user)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteUserAsync(User user)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Users.Remove(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task EditUserAsync(User user)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Users.Update(user);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Users.ToListAsync();
            }
        }

        public async Task<User> GetUserAsync(int idUser)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Users.FirstOrDefaultAsync(e => e.Id == idUser);
            }
        }
        public async Task<IEnumerable<User>> GetUsersByNameAsync(string userName)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Users.Where(e => e.Name.Contains(userName)).ToListAsync();
            }
        }

        public async Task<IEnumerable<User>> GetUsersWithSettingAsync()
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Users.Include(e => e.Settings).ToListAsync();
            }
        }
        public async Task<User> GetUserWithTransactionsAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Users.Include(e => e.Transactions).FirstOrDefaultAsync(e => e.Id == id);
            }
        }

    }
}
