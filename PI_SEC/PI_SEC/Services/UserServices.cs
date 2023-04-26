using PI_SEC.Entities;
using PI_SEC.Interfaces;
using PI_SEC.Interfaces.Services;

namespace PI_SEC.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepositories _userRepositories;
        public UserServices(IUserRepositories userRepositories)
        {
            _userRepositories = userRepositories;
        }

        public async Task<long> CreateUser(User req)
        {
            return await _userRepositories.Insert(req);
        }

        public async Task<bool> DeleteUser(long userId)
        {
            return await _userRepositories.Delete(userId);
        }

        public async Task<User> GetUser(long userId)
        {
            return await _userRepositories.Select(userId);
        }

        public async Task<long> UpdateUser(User req)
        {
            return await _userRepositories.Update(req);
        }
    }
}
