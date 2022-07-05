using Faculty_Information_System_Application.Data;
using Faculty_Information_System_Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Faculty_Information_System_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserRepository _repository;
        private IJWTManagerRepository _repository1;
        public UsersController(IUserRepository repository, IJWTManagerRepository repository1)
        {
            this._repository = repository;
            this._repository1 = repository1;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var UserList = _repository.GetUser();
            return Ok(UserList);

        }
        [HttpPost]
        public IActionResult Post(User use)
        {
            User obj = _repository.AddUser(use);
            return CreatedAtAction("get", new
            {
                Id = obj.UserId
            }, obj);
        }


        [HttpDelete]
        [Route("{userId}")]
        public IActionResult Delete(int userid)
        {
            bool result = _repository.DeleteUser(userid);
            if (result == true)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{userId}")]
        public IActionResult Get(int userId)
        {
            User obj = _repository.SearchUser(userId);
            if (obj != null)
            {
                return Ok(obj);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{userId}")]
        public IActionResult Put(int userId, [FromBody] User use)
        {
            _repository.UpdateUser(userId, use);
            return Ok();
        }

        [HttpGet]
        [Route("{username}/{password}")]
        public IActionResult ValidateUser(string username, string password)
        {
            var jwtToken = _repository1.Authenticate(username, password);
            if (jwtToken != null)
            {
                return Ok(jwtToken);
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}
