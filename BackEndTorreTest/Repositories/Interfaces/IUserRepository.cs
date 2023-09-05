using BackEndTorreTest.Models;

namespace BackEndTorreTest.Repositories.Interfaces
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        Task PostUser(User User);
        Task PutUser(User user);
    }
}
