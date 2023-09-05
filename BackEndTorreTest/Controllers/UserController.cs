using BackEndTorreTest.Models;
using BackEndTorreTest.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BackEndTorreTest.Controllers
{
    // UserController.cs (Capa de Presentación)
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
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
        public async Task<IActionResult> AddFavorites ([FromForm] User user)
        {
            await _userService.AddFavorite(user);
            return NoContent();
        }
        // Otras acciones de controlador...
    }

}
