using CRUD.Domain;
using CRUD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService userService;
        public UserController(UserService userService)
        {
            this.userService = userService;   
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(User user)
        {
            var result = await userService.AddUser(user);
            if(result == "User Added!")
            {
                return CreatedAtAction(null,null, user);
            }
            return BadRequest(result);
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await userService.Login(email, password);  
            if(result == "Login successfull")
            {
                Object obj = new {response=result };

                return CreatedAtAction(null, null, obj);
            }
            return BadRequest(result);
        }
    }
}
