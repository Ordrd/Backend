namespace OrdrdApi.Repositories.UserRepo
{
    public interface IUserRepository
    {
        Task<User?> GetUserAsync(string authId);
        Task<User?> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
    }
}
