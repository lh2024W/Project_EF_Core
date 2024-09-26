using Microsoft.EntityFrameworkCore;
using Project_EF_Core.Data;
using Project_EF_Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Project_EF_Core.Repository
{
    public class TransactionRepository : ITransaction
    {
        public async Task AddTransactionAsync(Project_EF_Core.Models.Transaction transaction)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Transactions.Add(transaction);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteTransactionAsync(Project_EF_Core.Models.Transaction transaction)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Project_EF_Core.Models.Transaction>> GetAllTransactionsAsync()
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Transactions.ToListAsync();
            }
        }

        public async Task<IEnumerable<Models.Transaction>> GetAllTransactionsByCategoryIdAsync(int idCategory)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Transactions.Include(e => e.Category.Id == idCategory).ToListAsync();
            }
        }

        public async Task<IEnumerable<Project_EF_Core.Models.Transaction>> GetAllTransactionsByDateAsync(DateTime dateTransaction)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Transactions.Where(e => e.DateTransaction == dateTransaction).ToListAsync();
            }
        }

        public async Task<IEnumerable<Models.Transaction>> GetAllTransactionsByUserNameAsync(string nameUser)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Transactions.Where(e => e.User.Name.Contains(nameUser)).ToListAsync();
            }
        }

        public async Task<Project_EF_Core.Models.Transaction> GetTransactionAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Transactions.FirstOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task UpdateTransactionAsync(Project_EF_Core.Models.Transaction transaction)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Transactions.Update(transaction);
                await context.SaveChangesAsync();
            }
        }
    }
}
