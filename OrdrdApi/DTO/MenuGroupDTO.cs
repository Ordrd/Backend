using OrdrdApi.Models;

namespace OrdrdApi.DTO
{
    public class MenuGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public bool IsVisible { get; set; }
        public int OrderIndex { get; set; }
        public int UserId { get; set; }

        public static MenuGroupDto FromMenuGroup(MenuGroup menuGroup)
        {

            return new MenuGroupDto
            {
                Id = menuGroup.MenuGroupId,
                Name = menuGroup.Name,
                IsVisible = menuGroup.Visible,
                OrderIndex = menuGroup.OrderIndex,
                UserId = menuGroup.UserId
            };
        }
    }
}
