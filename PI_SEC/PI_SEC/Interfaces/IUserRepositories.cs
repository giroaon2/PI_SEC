using PI_SEC.Entities;

namespace PI_SEC.Interfaces
{
    public interface IUserRepositories
    {
        Task<long> Insert(User req);
        Task<long> Update(User req);
        Task<bool> Delete(long userId);
        Task<User> Select(long userId);
    }
}