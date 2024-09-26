using Project_EF_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_EF_Core.Data
{
    public class DbInit
    {
        public void Init(ApplicationContext context)
        {
            if (!context.Users.Any())
            {
                context.Users.AddRange
                (
                    new User { Name = "Jess" },
                    new User { Name = "Martha" }
                );
                context.SaveChanges();
            }

            if (!context.Settings.Any())
            {
                context.Settings.AddRange
                (
                    new Setting { Email = "Jess.@gmail.com", Password = "111", UserId = 1 },
                    new Setting { Email = "Martha.@gmail.com", Password = "222", UserId = 2 }
                );
                context.SaveChanges();
            }

            if (!context.Categories.Any())
            {
                context.Categories.AddRange
                    (
                    new Category
                    {
                        Name = "Income"//доход
                    },
                    new Category
                    {
                        Name = "Сonsumption"//расход
                    }
                    );
                context.SaveChanges();
            }

            if (!context.Transactions.Any())
            {
                Transaction transaction = new Transaction
                {
                    DateTransaction = new DateTime(2024, 9, 10),
                    AmountOfMoney = 10000,
                    Description = "Salary.",
                    UserId = 1,
                    CategoryId = 1,
                };

                Transaction transaction1 = new Transaction
                {
                    DateTransaction = new DateTime(2024, 9, 12),
                    AmountOfMoney = 1700,
                    Description = "Payment for electricity.",
                    UserId = 1,
                    CategoryId = 2,
                };

                Transaction transaction2 = new Transaction
                {
                    DateTransaction = new DateTime(2024, 9, 13),
                    AmountOfMoney = 700,
                    Description = "Payment for internet.",
                    UserId = 1,
                    CategoryId = 2,
                };

                Transaction transaction3 = new Transaction
                {
                    DateTransaction = new DateTime(2024, 9, 2),
                    AmountOfMoney = 12300,
                    Description = "Salary.",
                    UserId = 2,
                    CategoryId = 1,
                };

                Transaction transaction4 = new Transaction
                {
                    DateTransaction = new DateTime(2024, 9, 11),
                    AmountOfMoney = 400,
                    Description = "Payment for electricity.",
                    UserId = 2,
                    CategoryId = 2,
                };

                Transaction transaction5 = new Transaction
                {
                    DateTransaction = new DateTime(2024, 9, 11),
                    AmountOfMoney = 520,
                    Description = "Payment for internet.",
                    UserId = 2,
                    CategoryId = 2,
                };
                context.Transactions.AddRange(new Transaction[]
                {
                   transaction, transaction1, transaction2, transaction3 ,transaction4, transaction5
                });

                context.SaveChanges();
            }
        }
    }
}

