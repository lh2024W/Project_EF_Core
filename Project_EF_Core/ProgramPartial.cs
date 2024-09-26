using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Project_EF_Core.Helpers;
using Project_EF_Core.Interfaces;
using Project_EF_Core.Models;
using Project_EF_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace Project_EF_Core
{
    public partial class Program
    {
       //Users

        static async Task ReviewUsers()
        {
            var allUsers = await _users.GetAllUsersAsync();
            var users = allUsers.Select(e => new ItemView { Id = e.Id, Value = e.Name }).ToList();
            int result = ItemsHelper.MultipleChoice(true, users, true);
            if (result != 0)
            {
                var currentUser = await _users.GetUserAsync(result);
                await UserInfo(currentUser);
            }
        }

        static async Task UserInfo(User currentUser)
        {
            int result = ItemsHelper.MultipleChoice(true, new List<ItemView>
            {
                new ItemView {Id = 1,  Value = "Browse users"},
                new ItemView { Id = 2, Value = "Edit user"},
                new ItemView { Id = 3, Value = "Delete user"}
            },
            IsMenu: true, message: String.Format("{0}\n", currentUser), startY: 5, optionsPerLine: 1);

            switch (result)
            {
                case 1:
                    {
                        await UserWithTransactions(currentUser);
                        break;
                    }
                case 2:
                    {
                        await EditUser(currentUser);
                        Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        await RemoveUser(currentUser);
                        Console.ReadLine();
                        break;
                    }
            }
            await ReviewUsers();
        }

        static async Task AddUser()
        {
            string userName = InputHelper.GetString("user 'Name'");
            await _users.AddUserAsync(new User
            {
                Name = userName
            });
            Console.WriteLine("User successfully added.");
        }

        static async Task EditUser(User currentUser)
        {
            Console.WriteLine("Changing: {0}", currentUser.Name);
            currentUser.Name = InputHelper.GetString("user 'Name'");
            await _users.EditUserAsync(currentUser);
            Console.WriteLine("User successfully changed.");
        }

        static async Task RemoveUser(User currentUser)
        {
            int result = ItemsHelper.MultipleChoice(true, new List<ItemView>
            {
                new ItemView { Id = 1, Value = "Yes"},
                new ItemView { Id = 2, Value = "No"},
            }, message: String.Format("{Are you sure you want to delete the user {0} ?}\n", currentUser.Name), startY: 2);

            if (result == 1)
            {
                await _users.DeleteUserAsync(currentUser);
                Console.WriteLine("The user has been successfully deleted.");
            }
            else
            {
                Console.WriteLine("Press any key to conrinue...");
            }
        }

        static async Task SearchUsers()
        {
            string userName = InputHelper.GetString("user name");
            var currentUsers = await _users.GetUsersByNameAsync(userName);
            if (currentUsers.Count() > 0)
            {
                var users = currentUsers.Select(e => new ItemView { Id = e.Id, Value = e.Name }).ToList();
                int result = ItemsHelper.MultipleChoice(true, users, true);
                if (result != 0)
                {
                    var currentUser = await _users.GetUserAsync(result);
                    await UserInfo(currentUser);
                }
            }
            else
            {
                Console.WriteLine("No users were found by this name.");
            }
        }

        static async Task UserWithTransactions(User currentUser)
        {
            var users = await _users.GetUserWithTransactionsAsync(currentUser.Id);
            var userWithTransactions = users.Transactions.Select(e => new ItemView { Id = e.Id, Value = e.Description }).ToList();
            int result = ItemsHelper.MultipleChoice(true, userWithTransactions, true);
            if (result != 0)
            {
                var currentUser1 = await _users.GetUserAsync(result);
                await UserInfo(currentUser1);
            }
        }


        //Settings

        static async Task ReviewSettings()
        {
            var allSettings = await _settings.GetAllSettingsAsync();
            var settings = allSettings.Select(e => new ItemView { Id = e.Id, Value = e.Email }).ToList();
            int result = ItemsHelper.MultipleChoice(true, settings, true);
            if (result != 0)
            {
                var currentSetting = await _settings.GetSettingAsync(result);
                await SettingInfo(currentSetting);
            }
        }

        static async Task SettingInfo(Setting currentSetting)
        {
            int result = ItemsHelper.MultipleChoice(true, new List<ItemView>
            {
                new ItemView {Id = 1,  Value = "Edit setting"},
                new ItemView { Id = 2, Value = "Delete setting"}
            },
            IsMenu: true, message: String.Format("{0}\n", currentSetting), startY: 5, optionsPerLine: 1);

            switch (result)
            {
                case 1:
                    {
                        await EditSetting(currentSetting);
                        Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        await RemoveSetting(currentSetting);
                        Console.ReadLine();
                        break;
                    }
            }
            await ReviewSettings();
        }


        static async Task AddSetting()
        {
            string email = InputHelper.GetString("user 'Email'");
            string password = InputHelper.GetString("user 'Password'");
            int userId = InputHelper.GetInt("user 'Id'");
            await _settings.AddSettingAsync(new Setting
            {
                Email = email,
                Password = password,
                UserId = userId
            });
            Console.WriteLine("User successfully added.");
        }

        static async Task EditSetting(Setting currentSetting)
        {
            Console.WriteLine("Changing: {0}", currentSetting.Password);
            currentSetting.Password = InputHelper.GetString("user 'Password'");
            await _settings.EditSettingAsync(currentSetting);
            Console.WriteLine("Setting successfully changed.");
        }

        static async Task RemoveSetting(Setting currentSetting)
        {
            int result = ItemsHelper.MultipleChoice(true, new List<ItemView>
            {
                new ItemView { Id = 1, Value = "Yes"},
                new ItemView { Id = 2, Value = "No"},
            }, message: String.Format("{Are you sure you want to delete the setting {0} ?}\n", currentSetting.Email), startY: 2);

            if (result == 1)
            {
                await _settings.DeleteSettingAsync(currentSetting);
                Console.WriteLine("The setting has been successfully deleted.");
            }
            else
            {
                Console.WriteLine("Press any key to conrinue...");
            }
        }

        static async Task SearchSettings()
        {
            string email = InputHelper.GetString("user 'email'");
            var currentSettings = await _settings.GetSettingByEmailAsync(email);
            if (currentSettings.Count() > 0)
            {
                var settings = currentSettings.Select(e => new ItemView { Id = e.Id, Value = e.Email }).ToList();
                int result = ItemsHelper.MultipleChoice(true, settings, true);
                if (result != 0)
                {
                    var currentSetting = await _settings.GetSettingAsync(result);
                    await SettingInfo(currentSetting);
                }
            }
            else
            {
                Console.WriteLine("No setting were found by this title.");
            }
        }


        //Categories

         static async Task ReviewCategories()
         {
             var allCategories = await _categories.GetAllCategoriesAsync();
             var categories = allCategories.Select(e => new ItemView { Id = e.Id, Value = e.Name }).ToList();
             int result = ItemsHelper.MultipleChoice(true, categories, true);
             if (result != 0)
             {
                 var currentCategory = await _categories.GetCategoryAsync(result);
                 await CategoryInfo(currentCategory);
             }
         }

         static async Task CategoryInfo(Category currentCategory)
         {
             int result = ItemsHelper.MultipleChoice(true, new List<ItemView>
             {
                 new ItemView {Id = 1, Value = "Total sum transactions by category"},
                 new ItemView {Id = 2, Value = "Browse categories"},
                 new ItemView {Id = 3, Value = "Edit category"},
                 new ItemView {Id = 4, Value = "Delete category"}
             },
             IsMenu: true, message: String.Format("{0}\n", currentCategory), startY: 5, optionsPerLine: 1);

             switch (result)
             {
                 case 1:
                     {
                         await TotalSumTransactionsByCategory(currentCategory);
                         Console.ReadLine();
                         break;
                     }

                case 2:
                    {
                        await CategoryWithTransactions(currentCategory);
                        Console.ReadLine();
                        break;
                    }
                case 3:
                     {
                         await EditCategory(currentCategory);
                         Console.ReadLine();
                         break;
                     }
                 case 4:
                     {
                         await RemoveCategory(currentCategory);
                         Console.ReadLine();
                         break;
                     }
             }
             await ReviewCategories();
         }

         static async Task AddCategory()
         {
             string categoryName = InputHelper.GetString("category 'Name'");
             
             await _categories.AddCategoryAsync(new Category
             {
                 Name = categoryName
             });
             Console.WriteLine("Category successfully added.");
         }

         static async Task EditCategory(Category currentCategory)
         {
             Console.WriteLine("Changing: {0}", currentCategory.Name);
             currentCategory.Name = InputHelper.GetString("category 'Name'");
             await _categories.UpdateCategoryAsync(currentCategory);
             Console.WriteLine("Category successfully changed.");
         }

         static async Task RemoveCategory(Category currentCategory)
         {
             int result = ItemsHelper.MultipleChoice(true, new List<ItemView>
             {
                 new ItemView { Id = 1, Value = "Yes"},
                 new ItemView { Id = 2, Value = "No"},
             }, message: String.Format("{Are you sure you want to delete the category {0} ?}\n", currentCategory.Name), startY: 2);

             if (result == 1)
             {
                 await _categories.DeleteCategoryAsync(currentCategory);
                 Console.WriteLine("The category has been successfully deleted.");
             }
             else
             {
                 Console.WriteLine("Press any key to conrinue...");
             }
         }

         static async Task SearchCategory()
         {
             string categoryName = InputHelper.GetString("category name");
             var currentCategories = await _categories.GetCategoriesByNameAsync(categoryName);
             if (currentCategories.Count() > 0)
             {
                 var categories = currentCategories.Select(e => new ItemView { Id = e.Id, Value = e.Name }).ToList();
                 int result = ItemsHelper.MultipleChoice(true, categories, true);
                 if (result != 0)
                 {
                     var currentCategory = await _categories.GetCategoryAsync(result);
                     await CategoryInfo(currentCategory);
                 }
             }
             else
             {
                 Console.WriteLine("No categories were found by this name.");
             }
         }

         static async Task CategoryWithTransactions(Category currentCategory)
         {
             var category = await _categories.GetCategoryWithTransactionsAsync(currentCategory.Id);
             var categoryWithTransactions = category.Transactions.Select(e => new ItemView { Id = e.Id, Value = e.Description }).ToList();
             int result = ItemsHelper.MultipleChoice(true, categoryWithTransactions, true);
             if (result != 0)
             {
                 var currentCategory1 = await _categories.GetCategoryAsync(result);
                 await CategoryInfo(currentCategory1);
             }
         }

        static async Task TotalSumTransactionsByCategory(Category currentCategory)
        {
            //хранимая процедура
            int @categoryId = InputHelper.GetInt("category 'Id'");
            SqlParameter param = new SqlParameter("@categoryId", "Acme Corporation");
            var sum = DbContext().Users.FromSqlRaw("TotalSumTransactionsByCategory @categoryId", param).ToList();

            int result = ItemsHelper.MultipleChoice(true, sum, true);
            if (result != 0)
            {
                var currentCategory1 = await _categories.GetCategoryAsync(result);
                await CategoryInfo(currentCategory1);
            }
        }
        
        //Transactions

        static async Task ReviewTransactions()
         {
             var allTransactions = await _transactions.GetAllTransactionsAsync();
             var transactions = allTransactions.Select(e => new ItemView { Id = e.Id, Value = e.Description }).ToList();
             int result = ItemsHelper.MultipleChoice(true, transactions, true);
             if (result != 0)
             {
                 var currentTransaction = await _transactions.GetTransactionAsync(result);
                 await TransactionInfo(currentTransaction);
             }
         }

         static async Task TransactionInfo(Transaction currentTransaction)
         {
             int result = ItemsHelper.MultipleChoice(true, new List<ItemView>
             {
                 new ItemView {Id = 1,  Value = "Edit transaction"},
                 new ItemView { Id = 2, Value = "Delete ransactions"}
             },
             IsMenu: true, message: String.Format("{0}\n", currentTransaction), startY: 5, optionsPerLine: 1);

             switch (result)
             {
                 case 1:
                     {
                         await EditTransaction(currentTransaction);
                         Console.ReadLine();
                         break;
                     }
                 case 2:
                     {
                         await RemoveTransaction(currentTransaction);
                         Console.ReadLine();
                         break;
                     }
             }
             await ReviewTransactions();
         }

         static async Task AddTransactions()
         {
             DateTime dateTransaction = InputHelper.GetDateTime("transaction 'Date'");
             decimal amountOfMoney = InputHelper.GetDecimal("transaction 'Amount of money'");
             string description = InputHelper.GetString("transaction 'Description'");
             int userId = InputHelper.GetInt("user 'Id'");
             int categoryId = InputHelper.GetInt("category 'Id'");

             await _transactions.AddTransactionAsync(new Transaction
             {
                 DateTransaction = dateTransaction,
                 AmountOfMoney = amountOfMoney,
                 Description = description,
                 UserId = userId,
                 CategoryId = categoryId
             });
             Console.WriteLine("Transaction successfully added.");
         }

         static async Task EditTransaction(Transaction currentTransaction)
         {
             Console.WriteLine("Changing: {0}", currentTransaction.AmountOfMoney);
            currentTransaction.AmountOfMoney = InputHelper.GetDecimal("transaction 'Amount of money'");
             await _transactions.UpdateTransactionAsync(currentTransaction);
             Console.WriteLine("Transaction successfully changed.");
         }

         static async Task RemoveTransaction(Transaction currentTransaction)
         {
             int result = ItemsHelper.MultipleChoice(true, new List<ItemView>
             {
                 new ItemView { Id = 1, Value = "Yes"},
                 new ItemView { Id = 2, Value = "No"},
             }, message: String.Format("{Are you sure you want to delete the transaction {0} ?}\n", currentTransaction.Description), startY: 2);

             if (result == 1)
             {
                 await _transactions.DeleteTransactionAsync(currentTransaction);
                 Console.WriteLine("The transaction has been successfully deleted.");
             }
             else
             {
                 Console.WriteLine("Press any key to conrinue...");
             }
         }

        static async Task SearchTransactions(Transaction currentTransaction)
        {
            int result = ItemsHelper.MultipleChoice(true, new List<ItemView>
             {
                 new ItemView {Id = 1,  Value = "Search transactions by date"},
                 new ItemView { Id = 2, Value = "Search transactions by user name"},
                 new ItemView { Id = 3, Value = "Search transactions by category"}
             },
             IsMenu: true, message: String.Format("{0}\n", currentTransaction), startY: 5, optionsPerLine: 1);

            switch (result)
            {
                case 1:
                    {
                        await SearchTransactionsByDate(currentTransaction);
                        Console.ReadLine();
                        break;
                    }
                case 2:
                    {
                        await SearchTransactionsByUserName(currentTransaction);
                        Console.ReadLine();
                        break;
                    }
                case 3:
                    {
                        await SearchTransactionsCategoryId(currentTransaction);
                        Console.ReadLine();
                        break;
                    }
            }
            await ReviewTransactions();
        }
        static async Task SearchTransactionsByDate(Transaction currentTransaction)
         {
             DateTime transactionsByDate = InputHelper.GetDateTime("transaction 'Date'");
             var currentTransactions = await _transactions.GetAllTransactionsByDateAsync(transactionsByDate);
             if (currentTransactions.Count() > 0)
             {
                 var transactions = currentTransactions.Select(e => new ItemView { Id = e.Id, Value = e.Description }).ToList();
                 int result = ItemsHelper.MultipleChoice(true, transactions, true);
                 if (result != 0)
                 {
                     var currentTransaction1 = await _transactions.GetTransactionAsync(result);
                     await TransactionInfo(currentTransaction1);
                 }
             }
             else
             {
                 Console.WriteLine("No transaction were found by this name.");
             }
         }

        static async Task SearchTransactionsByUserName(Transaction currentTransaction)
        {
            string transactionsByUserName = InputHelper.GetString("user 'Name'");
            var currentTransactions = await _transactions.GetAllTransactionsByUserNameAsync(transactionsByUserName);
            if (currentTransactions.Count() > 0)
            {
                var transactions = currentTransactions.Select(e => new ItemView { Id = e.Id, Value = e.Description }).ToList();
                int result = ItemsHelper.MultipleChoice(true, transactions, true);
                if (result != 0)
                {
                    var currentTransaction1 = await _transactions.GetTransactionAsync(result);
                    await TransactionInfo(currentTransaction1);
                }
            }
            else
            {
                Console.WriteLine("No transaction were found by this name.");
            }
        }

        static async Task SearchTransactionsCategoryId(Transaction currentTransaction)
        {
            int transactionsByCategoryId = InputHelper.GetInt("category 'Id'");
            var currentTransactions = await _transactions.GetAllTransactionsByCategoryIdAsync(transactionsByCategoryId);
            if (currentTransactions.Count() > 0)
            {
                var transactions = currentTransactions.Select(e => new ItemView { Id = e.Id, Value = e.Description }).ToList();
                int result = ItemsHelper.MultipleChoice(true, transactions, true);
                if (result != 0)
                {
                    var currentTransaction1 = await _transactions.GetTransactionAsync(result);
                    await TransactionInfo(currentTransaction1);
                }
            }
            else
            {
                Console.WriteLine("No transaction were found by this name.");
            }
        }
    }
}
