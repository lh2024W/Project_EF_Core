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
                        Name = "Utility payments"//комунальные платежи
                    },
                    new Category
                    {
                        Name = "Grocery shopping"//закупка продуктов
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}

