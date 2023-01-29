using OrdrdApi.Models;

namespace OrdrdApi.DTO
{
    public class OptionDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsMultiselectEnabled { get; set; }
        public int UserId { get; set; }
        public int ItemId { get; set; }
        public List<ChoiceDto> Choices { get; set; } = new List<ChoiceDto>();

        public static OptionDto FromOption(Option option)
        {
            List<ChoiceDto> choices = new List<ChoiceDto>();
            option.Choices.ForEach(choice => choices.Add(ChoiceDto.FromChoice(choice)));

            return new OptionDto
            {
                Id = option.OptionId,
                Name = option.Name,
                IsMultiselectEnabled = option.IsMultiselectEnabled,
                UserId = option.UserId,
                ItemId = option.ItemId,
                Choices = choices
            };
        }
    }
}
