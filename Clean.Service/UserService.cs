using AutoMapper;
using Clean.Core.DTOs;
using Clean.Core.Entities;
using Clean.Core.Repositories;
using Clean.Core.Services;

namespace Clean.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public List<UserDto> GetList()
        {
            //TODO business logic
            var users = _userRepository.GetAll();
            var list = _mapper.Map<IEnumerable<UserDto>>(users).ToList();
            return list;
        }

        public User GetById(int id)
        {
            return _userRepository.GetByID(id);
        }

        public User Update(int id, User user)
        {
            return _userRepository.Update(id, user);
        }

        public User Add(User user)
        {
            return _userRepository.Add(user);
        }
    }
}
