using Microsoft.EntityFrameworkCore;
using PI_SEC.Entities;
using PI_SEC.Interfaces;

namespace PI_SEC.Repositories
{
    public class UserRepositories : IUserRepositories
    {
        private readonly PiSecContext _piSecContext;
        public UserRepositories(PiSecContext piSecContext)
        {
            _piSecContext = piSecContext;
        }

        public async Task<bool> Delete(long userId)
        {
            User user = new User();
            user.Id = userId;
            _piSecContext.Users.Remove(user);
            return await _piSecContext.SaveChangesAsync() > 0;
        }

        public async Task<long> Insert(User req)
        {
            User user = new User();
            user.UserName = req.UserName;
            user.Email = req.Email;
            user.CreatedDate = req.CreatedDate;
            user.CreatedBy = req.CreatedBy;
            _piSecContext.Users.Add(user);
            _piSecContext.SaveChanges();
            return user.Id;
        }

        public async Task<User> Select(long userId)
        {
            return await _piSecContext.Users.FirstOrDefaultAsync(x => x.Id == userId);

        }

        public async Task<long> Update(User req)
        {
            User user = await _piSecContext.Users.FirstOrDefaultAsync(user => user.Id == req.Id);
            if (user == null) return 0;
            user.UserName = req.UserName;
            user.Email = req.Email;
            user.UpdateDate = req.UpdateDate;
            user.UpdateBy = req.UpdateBy;
            _piSecContext.SaveChangesAsync();
            return req.Id;
        }

    }
}
