using OrdrdApi.Models;
using Polly;
using System.Collections.Generic;
using System.Drawing.Printing;

namespace OrdrdApi.Repositories.MenuGroupRepo
{
    public class MenuGroupRepository : IMenuGroupRepository
    {
        private readonly DataContext context;

        public MenuGroupRepository(DataContext context)
        {
            this.context = context;
        }

        public async Task<MenuGroup> CreateMenuGroupAsync(MenuGroup menuGroup)
        {
            context.MenuGroups.Add(menuGroup);
            await context.SaveChangesAsync();

            return menuGroup;
        }

        public async Task DeleteMenuGroupAsync(int menuGroupId)
        {
            var itemDb = await context.MenuGroups.FindAsync(menuGroupId);
            if (itemDb != null)
            {
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<MenuGroup>> GetAllMenuGroupsAsync()
        {
            List<MenuGroup> menuGroups = await context.MenuGroups.OrderBy(group => group.OrderIndex).ToListAsync();
            return menuGroups;
        }

        public async Task UpdateMenuGroupAsync(MenuGroup menuGroup)
        {
            var itemDb = await context.Items.FindAsync(menuGroup.MenuGroupId);
            if (itemDb != null)
            {
                itemDb.Name = menuGroup.Name;
            }

            await context.SaveChangesAsync();
        }
    }
}
