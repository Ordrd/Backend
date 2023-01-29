namespace OrdrdApi.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string CompanyVAT { get; set; } = string.Empty;
        public string AuthUserId { get; set; } = string.Empty;

        public static UserDto FromUser(User user)
        {
            return new UserDto
            {
                Id = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Address = user.Address,
                City = user.City,
                CompanyName = user.CompanyName,
                CompanyVAT = user.CompanyVAT,
                AuthUserId = user.AuthUserId
            };
        }
    }
}
