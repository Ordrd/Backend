using Microsoft.Extensions.Hosting;
using OrdrdApi.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.Models
{
    public class MenuGroup
    {
        public int MenuGroupId { get; set; }
        public string Name { get; set; } = string.Empty;

        //Foreign keys
        public int UserId { get; set; }
        public User? User { get; set; }

        //ER Relations
        public List<Item> Item { get; set; } = new List<Item>();

        //public static Choice FromChoiceDto(ChoiceDto choice)
        //{
        //    return new Choice
        //    {
        //        ChoiceId = choice.Id,
        //        Name = choice.Name,
        //        Price = choice.Price,
        //        UserId = choice.UserId,
        //    };
        //}
    }
}
