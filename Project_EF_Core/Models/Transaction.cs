using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_EF_Core.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime DateTransaction { get; set; }
        public decimal AmountOfMoney { get; set; }
        public string Description { get; set; }

        public User? User { get; set; }
        public int UserId { get; set; }

        public Category? Category { get; set; }
        public int CategoryId { get; set; }


        public override string ToString()
        {
            return String.Format("DateTransaction - {0}\n AmountOfMoney - {1} Description - {2}", DateTransaction.ToShortDateString(), 
                AmountOfMoney, Description);
        }
    }
}
