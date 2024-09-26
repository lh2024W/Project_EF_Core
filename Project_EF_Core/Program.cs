using Project_EF_Core.Data;
using Project_EF_Core.Helpers;
using Project_EF_Core.Interfaces;
using Project_EF_Core.Repository;

namespace Project_EF_Core
{
    public partial class Program
    {
        public static ApplicationContext DbContext() => new ApplicationContextFactory().CreateDbContext();
        private static IUser _users;
        private static ICategory _categories;
        private static ISetting _settings;
        private static ITransaction _transactions;

        enum ShopMenu
        {
            Users, SearchUsers, AddUser, Settings, SearchSettings, AddSetting, Categories, SearchCategories, AddCategory,
            Transactions, SearchTransactions, AddTransaction, Exit
        }
        
        static async Task Main()
        {
            Initialize();

            int input = ConsoleHelper.MultipleChoice(true, new ShopMenu());

            do
            {
                input = ConsoleHelper.MultipleChoice(true, new ShopMenu());

                switch ((ShopMenu)input)
                {
                    case ShopMenu.Users:
                        await ReviewUsers();
                        break;
                    case ShopMenu.SearchUsers:
                        await SearchUsers();
                        break;
                    case ShopMenu.AddUser:
                        await AddUser();
                        break;
                    case ShopMenu.Settings:
                        await ReviewSettings();
                        break;
                    case ShopMenu.SearchSettings:
                        await SearchSettings();
                        break;
                    case ShopMenu.AddSetting:
                        await AddSetting();
                        break;
                    case ShopMenu.Categories:
                        await ReviewCategories();
                        break;
                    case ShopMenu.SearchCategories:
                        await SearchCategory();
                        break;
                    case ShopMenu.AddCategory:
                        await AddCategory();
                        break;
                    case ShopMenu.Transactions:
                        await ReviewTransactions();
                        break;
                    case ShopMenu.SearchTransactions:
                        await SearchTransactions();
                        break;
                    case ShopMenu.AddTransaction:
                        await AddTransactions();
                        break;
                    case ShopMenu.Exit:
                        break;
                    default:
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadLine();
            } while (ShopMenu.Exit != (ShopMenu)input);
        
    }
    static void Initialize()
        {
            new DbInit().Init(DbContext());
            _users = new UserRepository();
            _categories = new CategoryRepository();
            _settings = new SettingRepository();
            _transactions = new TransactionRepository();
        }
    }
}
