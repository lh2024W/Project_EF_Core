using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Project_EF_Core.Interfaces
{
    public interface ITransaction
    {
        Task<IEnumerable<Project_EF_Core.Models.Transaction>> GetAllTransactionsAsync();
        Task<IEnumerable<Project_EF_Core.Models.Transaction>> GetAllTransactionsByDateAsync(DateTime dateTransaction);
        Task<IEnumerable<Project_EF_Core.Models.Transaction>> GetAllTransactionsByUserNameAsync(string nameUser);
        Task<IEnumerable<Project_EF_Core.Models.Transaction>> GetAllTransactionsByCategoryIdAsync(int idCategory);
        Task<Project_EF_Core.Models.Transaction> GetTransactionAsync(int id);
        

        Task AddTransactionAsync(Project_EF_Core.Models.Transaction transaction);
        Task UpdateTransactionAsync(Project_EF_Core.Models.Transaction transaction);
        Task DeleteTransactionAsync(Project_EF_Core.Models.Transaction transaction);
    }
}
