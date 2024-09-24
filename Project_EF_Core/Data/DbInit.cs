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
                    new User { Name = "Jess", Settings = new Setting { Email = "Jess.@gmail.com", Password = "111"} },
                    new User { Name = "Martha", Settings = new Setting { Email = "Martha.@gmail.com", Password = "222" } }
                );
                context.SaveChanges();
            }
        }
    }
}

