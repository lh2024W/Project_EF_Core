using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_EF_Core.Models
{
    public class Setting
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User? User { get; set; }
        public int UserId { get; set; }


        public override string ToString()
        {
            return String.Format("Email - {0}\n Password - {1}", Email, Password);
        }
    }
}
