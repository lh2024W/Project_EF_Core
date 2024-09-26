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
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserWithTransactionsAsync(int id);
        Task<IEnumerable<User>> GetUsersWithSettingAsync();
        Task<User> GetUserAsync(int idUser);
        Task<IEnumerable<User>> GetUsersByNameAsync(string userName);
        
        
        Task AddUserAsync(User user);
        Task DeleteUserAsync(User user);
        Task EditUserAsync(User user);
    }
}
