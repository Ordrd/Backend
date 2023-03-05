using Microsoft.Extensions.Hosting;
using OrdrdApi.Models;

namespace OrdrdApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<MenuGroup> Menu{ get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Choice> Choices { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<OrderOption> OrderOptions { get; set; }
        public DbSet<OrderChoice> OrderChoices { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurant>()
                .HasOne(p => p.User)
                .WithMany(b => b.Restaurants)
                .HasForeignKey(r => r.UserId);

            //MENU GROUP
            modelBuilder.Entity<MenuGroup>()
                .HasOne(p => p.User)
                .WithMany(b => b.MenuGroups)
                .HasForeignKey(r => r.UserId);

            // ITEM
            modelBuilder.Entity<Item>()
                .HasOne(p => p.User)
                .WithMany(b => b.Items)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Item>()
                .HasOne(p => p.Restaurant)
                .WithMany(b => b.Items)
                .HasForeignKey(r => r.RestaurantId);

            modelBuilder.Entity<Item>()
                .HasOne(p => p.MenuGroup)
                .WithMany(b => b.Items)
                .HasForeignKey(r => r.MenuGroupId)
                .OnDelete(DeleteBehavior.NoAction);

            // OPTION
            modelBuilder.Entity<Option>()
                .HasOne(p => p.User)
                .WithMany(b => b.Options)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Option>()
                .HasOne(p => p.Item)
                .WithMany(b => b.Options)
                .HasForeignKey(r => r.ItemId);

            // CHOICE
            modelBuilder.Entity<Choice>()
                .HasOne(p => p.User)
                .WithMany(b => b.Choices)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Choice>()
                .HasOne(p => p.Option)
                .WithMany(b => b.Choices)
                .HasForeignKey(r => r.OptionId);

            // ORDER
            modelBuilder.Entity<Order>()
                .HasOne(p => p.User)
                .WithMany(b => b.Orders)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(p => p.Restaurant)
                .WithMany(b => b.Orders)
                .HasForeignKey(r => r.RestaurantId);

            //ORDER ITEM
            modelBuilder.Entity<OrderItem>()
                .HasOne(p => p.User)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderItem>()
                .HasOne(p => p.Item)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(r => r.ItemId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(p => p.Order)
                .WithMany(b => b.OrderItems)
                .HasForeignKey(r => r.OrderId)
                .OnDelete(DeleteBehavior.NoAction);

            //ORDER OPTION
            modelBuilder.Entity<OrderOption>()
                .HasOne(p => p.User)
                .WithMany(b => b.OrderOptions)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderOption>()
                .HasOne(p => p.Option)
                .WithMany(b => b.OrderOptions)
                .HasForeignKey(r => r.OptionId);

            modelBuilder.Entity<OrderOption>()
                .HasOne(p => p.OrderItem)
                .WithMany(b => b.OrderOptions)
                .HasForeignKey(r => r.OrderItemId)
                .OnDelete(DeleteBehavior.NoAction);

            //ORDER CHOICE
            modelBuilder.Entity<OrderChoice>()
                .HasOne(p => p.User)
                .WithMany(b => b.OrderChoices)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderChoice>()
                .HasOne(p => p.Choice)
                .WithMany(b => b.OrderChoices)
                .HasForeignKey(r => r.ChoiceId);

            modelBuilder.Entity<OrderChoice>()
                .HasOne(p => p.OrderOption)
                .WithMany(b => b.OrderChoices)
                .HasForeignKey(r => r.OrderOptionId)
                .OnDelete(DeleteBehavior.NoAction);
        }

    }
}
