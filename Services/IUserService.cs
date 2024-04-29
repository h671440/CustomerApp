using CustomerApp.Dataa;
using CustomerApp.Models.Entities;

namespace CustomerApp.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

       // Task<ApplicationUser> ValidateUser(string username, string password);
    }
}