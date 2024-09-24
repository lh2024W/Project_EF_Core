using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_EF_Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Setting? Settings { get; set; }
        

        public virtual ICollection<Transaction> Transactions { get; set; }



        public override string ToString()
        {
            return String.Format("Name - {0}\n", Name);
        }
    }
}
