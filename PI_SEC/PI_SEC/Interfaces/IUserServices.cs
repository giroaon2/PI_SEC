using PI_SEC.Entities;

namespace PI_SEC.Interfaces.Services
{
    public interface IUserServices
    {      
        Task<User> GetUser(long userId);
        Task<long> UpdateUser(User req);
        Task<long> CreateUser(User req);
        Task<bool> DeleteUser(long userId);
    }
}
