using Clean.Core.Entities;
using Clean.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clean.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User GetByID(int id)
        {
            //return _context.Users.FirstOrDefault(u => u.Id == id);
            return _context.Users.Find(id);
        }

        public User Update(int id, User user)
        {
            var existUser = GetByID(id);

            existUser.FirstName = user.FirstName;
            existUser.LastName = user.LastName;

            _context.Users.Update(user);
            _context.SaveChangesAsync();
            return existUser;
        }

        public User Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChangesAsync();
            return user;
        }

        public void Delete(int id)
        {
            var user = GetByID(id);
            _context.Users.Remove(user);
            _context.SaveChangesAsync();
        }
    }
}
