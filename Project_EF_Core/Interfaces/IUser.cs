using Project_EF_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_EF_Core.Interfaces
{
    public interface IUser
    {
        Task<User> GetUserWithTransactionsAsync(int id);
        Task<User> GetUserWithSettingAsync(int id);
        Task<User> GetUserAsync(int id);
        
        
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task EditUserAsync(User user);
    }
}
