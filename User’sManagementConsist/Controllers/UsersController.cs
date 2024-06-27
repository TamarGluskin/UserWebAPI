using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using User_sManagementConsist.Repositories;
using UsersManagementConsist.Model;

namespace User_sManagementConsist.Controllers
{
    [ApiController]
    [Route("api/UsersController")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }



        [HttpPost]
        [Route("createUser")]

        public IActionResult CreateUser([FromBody] User user)
        {
            try
            {
                _userRepository.CreateUser(user);
                return Ok("The user added sucssesfull");
            }
            catch (Exception ex)
            {

               return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("deleteUser")]
        public IActionResult DeleteUser(int userId)
        {
            try
            {
                _userRepository.DeleteUser(userId);
                return Ok("user had been deleted");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("validateUser")]
        public IActionResult ValidateUser([FromBody] User user)
        {
            try
            {
             var isValid = _userRepository.ValidateUser(user.UserName, user.UserPassword);
                if (isValid)
                {
                return Ok("The user validate");
                }
            

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Unauthorized();
        }

        [HttpGet]
        [Route("getUsers")]
        public IEnumerable<User> GetUsers()
        {
            try
            {
                return _userRepository.GetUsers();
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}

