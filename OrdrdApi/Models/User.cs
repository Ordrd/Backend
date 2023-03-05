using Microsoft.Extensions.Hosting;
using OrdrdApi.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty; 
        public string CompanyVAT { get; set; } = string.Empty;
        public string AuthUserId { get; set; } = string.Empty;

        //ER Relations
        public List<Restaurant> Restaurants { get; set; } = new List<Restaurant>();
        public List<Item> Items { get; set; } = new List<Item>();
        public List<MenuGroup> MenuGroups { get; set; } = new List<MenuGroup>();
        public List<Option> Options { get; set; } = new List<Option>();
        public List<Choice> Choices { get; set; } = new List<Choice>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
        public List<OrderOption> OrderOptions { get; set; } = new List<OrderOption>();
        public List<OrderChoice> OrderChoices { get; set; } = new List<OrderChoice>();


        public static User FromUserDto(UserDto userDto)
        {
            return new User
            {
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                Address = userDto.Address,
                City = userDto.City,
                CompanyName = userDto.CompanyName,
                CompanyVAT = userDto.CompanyVAT,
                AuthUserId = userDto.AuthUserId,
            };
        }
    }
}
