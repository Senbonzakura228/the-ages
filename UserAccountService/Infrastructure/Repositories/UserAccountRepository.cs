using Domain.Entities.User;
using Infrastructure.DAO;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserAccountRepository
    {
        private UserAccountDBContext dbContext;

        public UserAccountRepository(UserAccountDBContext context)
        {
            dbContext = context;
        }

        public async Task<User?> GetUserByName(string name)
        {
            var users = await dbContext.userAccounts.AsNoTracking().ToListAsync();
            var user = users.Where(user => user.UserName == name).FirstOrDefault();
            if (user == null) return null;
            return new User(user.UserName, user.PasswordHash, user.Id);
        }

        public async Task<int> Add(User user)
        {
            var userEntity = new UserAccount()
            {
                UserName = user.name,
                PasswordHash = user.passwordHash,
            };

            await dbContext.AddAsync(userEntity);
            await dbContext.SaveChangesAsync();
            var userId = userEntity.Id;
            return userId;
        }
    }
}