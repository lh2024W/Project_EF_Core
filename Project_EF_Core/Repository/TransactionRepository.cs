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
        public async Task AddTransactionAsync(Transaction transaction)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Transactions.Add(transaction);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteTransactionAsync(Transaction transaction)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Transactions.Remove(transaction);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsAsync()
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Transactions.ToListAsync();
            }
        }

        public async Task<IEnumerable<Transaction>> GetAllTransactionsByDateAsync(DateTime dateTransaction)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Transactions.Where(e => e.DateTransaction == dateTransaction).ToListAsync();
            }
        }

        public async Task<Transaction> GetTransactionAsync(int id)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                return await context.Transactions.FirstOrDefaultAsync(e => e.Id == id);
            }
        }

        public async Task UpdateTransactionAsync(Transaction transaction)
        {
            using (ApplicationContext context = Program.DbContext())
            {
                context.Transactions.Update(transaction);
                await context.SaveChangesAsync();
            }
        }
    }
}
