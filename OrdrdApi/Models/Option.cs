using Microsoft.Extensions.Hosting;
using OrdrdApi.DTO;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrdrdApi.Models
{
    public class Option
    {
        public int OptionId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsMultiselectEnabled { get; set; }

        //Foreign keys
        public int UserId { get; set; }
        public User? User { get; set; }
        public int ItemId { get; set; }
        public Item? Item { get; set; }

        //ER Relations
        public List<Choice> Choices { get; set; } = new List<Choice>();
        public List<OrderOption> OrderOptions { get; set; } = new List<OrderOption>();

        public static Option FromOptionDto(OptionDto option)
        {
            List<Choice> choices = new List<Choice>();
            option.Choices.ForEach(choice => choices.Add(Choice.FromChoiceDto(choice)));

            return new Option
            {
                OptionId = option.Id,
                Name = option.Name,
                IsMultiselectEnabled = option.IsMultiselectEnabled,
                UserId = option.UserId,
                Choices = choices
            };
        }
    }
}
