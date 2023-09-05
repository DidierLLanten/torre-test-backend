using BackEndTorreTest.Models;

namespace BackEndTorreTest.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetAllUsers(string userSearch);
        User GetUserById(int id);
        Task AddFavorite(User user);
    }
}
