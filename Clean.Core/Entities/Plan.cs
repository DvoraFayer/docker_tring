using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class Plan
    {
        public int IdPlan { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public List<User> Users { get; set; }
    }
}
