namespace OrdrdApi.Services.UserServ
{
    public interface IUserService
    {
        Task<User?> GetUserAsync(string authId);
        Task<User?> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(User user);
    }
}

