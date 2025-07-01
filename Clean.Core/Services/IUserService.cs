using Clean.Core.DTOs;
using Clean.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Core.Services
{
    public interface IUserService
    {
        public List<UserDto> GetList();
        public User GetById(int id);
        public User Update(int id, User user);

        public User Add(User user);
    }
}
