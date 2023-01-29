using Microsoft.AspNetCore.Http.HttpResults;
using OrdrdApi.Models;
using Polly;

namespace OrdrdApi.Repositories.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;

        public UserRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> GetUserAsync(string authId)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.AuthUserId == authId);
            if (user == null)
            {
                return null;
            }
            return user;
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }
            return user;
        }
    }
}
