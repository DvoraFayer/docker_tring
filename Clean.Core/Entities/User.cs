using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Plan Plan { get; set; }
        public int PlanId {  get; set; }
        public UserSettings Settings { get; set; }
        public int UserSettingsId { get; set; }
        public List<Team> Teams { get; set; }
    }
}
