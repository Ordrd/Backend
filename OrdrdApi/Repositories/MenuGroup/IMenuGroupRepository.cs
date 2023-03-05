namespace OrdrdApi.Repositories.MenuGroupRepo
{
    public interface IMenuGroupRepository
    {
        Task<List<MenuGroup>> GetAllMenuGroupsAsync();
        Task<MenuGroup> CreateMenuGroupAsync(MenuGroup menuGroup);
        Task UpdateMenuGroupAsync(MenuGroup menuGroup);
        Task DeleteMenuGroupAsync(int menuGroupId);
    }
}
