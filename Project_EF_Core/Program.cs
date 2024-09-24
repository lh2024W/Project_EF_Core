using Project_EF_Core.Data;

namespace Project_EF_Core
{
    public class Program
    {
        public static ApplicationContext DbContext() => new ApplicationContextFactory().CreateDbContext();

        static void Main()
        {
            new DbInit().Init(DbContext());
        }
    }
}
