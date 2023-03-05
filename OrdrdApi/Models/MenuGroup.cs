using OrdrdApi.DTO;

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
        public List<Item> Items { get; set; } = new List<Item>();

        public static MenuGroup FromMenuGroupDto(MenuGroupDto menuGroup)
        {
            return new MenuGroup
            {
                MenuGroupId = menuGroup.Id,
                Name = menuGroup.Name,
                UserId = menuGroup.UserId,
            };
        }
    }
}
