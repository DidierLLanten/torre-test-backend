using BackEndTorreTest.Models;
using BackEndTorreTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndTorreTest.Controllers
{    
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpPost("buscarPorNombre")]
        public async Task<IActionResult> GetAllUsers([FromBody] string? userSearch)
        {
            var users = await _userService.GetAllUsers(userSearch);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddFavorites([FromBody] User user)
        {
            await _userService.AddFavorite(user);
            return NoContent();
        }

        [HttpGet]
        public IActionResult GetFavoriteUsers()
        {
            var favoriteUsers = _userService.GetFavoriteUsers();
            return Ok(favoriteUsers);
        }
    }

}
