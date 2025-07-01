using Clean.Core.DTOs;
using Clean.Core.Entities;
using Clean.Core.Services;
using Clean.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clean.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;


        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet("/demo")]
        public string GetDemo()
        {
            return "You succeed!";
        }

        // GET: api/<UsersController>
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<UserDto>> Get()
        {
            return _userService.GetList();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _userService.GetById(id);
            if (user is null)
            {
                return NotFound();
            }
            return user;
        }


        // POST api/<UsersController>
        [HttpPost]
        public ActionResult<User> Post([FromBody] User user)
        {
            // validation
            var newUser = _userService.Add(user);
            return user;
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            //validation
            var existUser = _userService.GetById(id);
            if (existUser is null)
            {
                return NotFound();
            }
            var updateUser = _userService.Update(id, user);
            return updateUser;
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
