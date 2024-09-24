using Project_EF_Core.Data;
using Project_EF_Core.Interfaces;
using Project_EF_Core.Repository;

namespace Project_EF_Core
{
    class Program
    {
        public static ApplicationContext DbContext() => new ApplicationContextFactory().CreateDbContext();
        private static IUser _users;


        static async Task Main()
        {
            Initialize();


            var allUsers = await _users.GetUserWithSettingAsync(1);


        }
        static void Initialize()
        {
            new DbInit().Init(DbContext());
            _users = new UserRepository();
        }
    }
}
