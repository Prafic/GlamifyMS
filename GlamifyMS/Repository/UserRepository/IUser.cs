using FinalProject.Models;

namespace FinalProject.Repository.UserRepository
{
    public interface IUser
    {

        Task<List<User>> GetAll();

        Task<User> AddUserAsync(User user);

       // Task<User> Login(string email, string password);
        string Login(string email, string password);
        Task<User> UpdateUserDetail(int id, User user);
    }
}
