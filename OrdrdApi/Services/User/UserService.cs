using OrdrdApi.Models;
using OrdrdApi.Repositories.UserRepo;

namespace OrdrdApi.Services.UserServ
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await userRepository.CreateUserAsync(user);
            return user;
        }


        public async Task<User?> GetUserAsync(string authId)
        {
            var user = await userRepository.GetUserAsync(authId);
            return user;
        }
        public async Task<User?> GetUserByIdAsync(int id)
        {
            var user = await userRepository.GetUserByIdAsync(id);
            return user;
        }
    }
}
