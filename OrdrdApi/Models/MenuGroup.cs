using OrdrdApi.DTO;

namespace OrdrdApi.Models
{
    public class MenuGroup
    {
        public int MenuGroupId { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool Visible { get; set; } = true;
        public int OrderIndex { get; set; }

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
                Visible = menuGroup.IsVisible,
                OrderIndex = menuGroup.OrderIndex,
                UserId = menuGroup.UserId,
            };
        }
    }
}
