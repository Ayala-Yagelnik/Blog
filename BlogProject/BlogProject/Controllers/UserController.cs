using Microsoft.AspNetCore.Mvc;
using BlogProject.Entities;
using BlogProject.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlogProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        readonly UserService _data;
        public UserController(UserService userService)
        {
            _data = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var users = _data.Get();
            return users == null ? NotFound() : users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            var user = _data.GetById(id);
            return user == null ? NotFound() : user;
        }

        // POST api/<UserController>
        [HttpPost]
        public ActionResult<bool> Post([FromBody] User user)
        {
            bool success = _data.AddUser(user);
            return success ? true : NotFound();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public ActionResult<bool> Put(int id, [FromBody] User user)
        {
            bool success = _data.Update(id, user);
            return success ? true : NotFound();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public ActionResult<bool> Delete(int id)
        {
            bool success = _data.Delete(id);
            return success ? true : NotFound();
        }
    }
}
