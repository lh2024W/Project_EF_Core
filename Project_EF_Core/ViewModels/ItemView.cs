using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_EF_Core.ViewModels
{
    public class ItemView : IShow<int>
    {
        public int Id { get; set; }
        public string Value { get; set; }
    }
}
