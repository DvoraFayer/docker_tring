using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class UserSettings
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public int Size { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}
