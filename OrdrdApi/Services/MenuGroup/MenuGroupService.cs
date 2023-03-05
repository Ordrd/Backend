using OrdrdApi.DTO;
using OrdrdApi.Repositories.MenuGroupRepo;

namespace OrdrdApi.Services.MenuGroupServ
{
    public class MenuGroupService : IMenuGroupService
    {
        private readonly IMenuGroupRepository menuGroupRepository;

        public MenuGroupService(IMenuGroupRepository menuGroupRepository)
        {
            this.menuGroupRepository = menuGroupRepository;
        }

        public async Task<MenuGroupDto> CreateMenuGroupAsync(MenuGroupDto menuGroupDTO)
        {
            var menuGroup = MenuGroup.FromMenuGroupDto(menuGroupDTO);
            var result = await menuGroupRepository.CreateMenuGroupAsync(menuGroup);
            return MenuGroupDto.FromMenuGroup(result);
        }


        public async Task DeleteMenuGroupAsync(int menuGroupId)
        {
            await menuGroupRepository.DeleteMenuGroupAsync(menuGroupId);
        }

        public async Task<List<MenuGroupDto>> GetAllMenuGroupsAsync()
        {
            var menuGroups = await menuGroupRepository.GetAllMenuGroupsAsync();
            List<MenuGroupDto> menuGroupDtos = new List<MenuGroupDto>();
            menuGroups.ForEach(menuGroup => menuGroupDtos.Add(MenuGroupDto.FromMenuGroup(menuGroup)));

            return menuGroupDtos;
        }

        public async Task UpdateMenuGroupAsync(MenuGroupDto menuGroupDTO)
        {
            var menuGroup = MenuGroup.FromMenuGroupDto(menuGroupDTO);
            await menuGroupRepository.UpdateMenuGroupAsync(menuGroup);
        }
    }
}
