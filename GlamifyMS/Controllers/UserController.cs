using FinalProject.Models;
using FinalProject.Repository.UserRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase // defined for handling http request
    {

        private readonly IUser userInterface;
        public UserController(IUser userInterface)
        {
            this.userInterface = userInterface;

        }



        [HttpGet("GetAll")]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            var result = await userInterface.GetAll();
            if (result != null)
            {
                return Ok(result);//response dera 2xx 
            }
            return NotFound();
        }
       
          

        [HttpPut("updateUser/{id}")]

        public async Task<ActionResult<User>> UpdateUser(int id, [FromBody] User user)
        {
            var result = await userInterface.UpdateUserDetail(id, user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost("login")]
        public string Login(string email, string password)
        {
            var result = userInterface.Login(email, password);

            if (result != null)
            {
                return result;
            }
            return null;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult<User>> AddUser([FromBody] User user)
        {
            var result = await userInterface.AddUserAsync(user);
            if (result != null)
            {
                return Ok(result);
            }
            return BadRequest("User already exist.Please login");

        }

    }
}
