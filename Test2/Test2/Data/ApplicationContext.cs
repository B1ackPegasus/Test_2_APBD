using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Test2.Models;

namespace Test2.Data;


public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Backpack> Backpacks { get; set; }
    public DbSet<Character> Character { get; set; }
    public DbSet<Character_Title> Character_Title { get; set; }
    public DbSet<Item> Item { get; set; }
    public DbSet<Title> Title { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Item>().HasData(new List<Item>
        {
            new Item { Id = 1, Name = "Apple", Weight = 200 },
            new Item { Id = 2, Name = "Knife", Weight = 150 },

        });

        modelBuilder.Entity<Character>().HasData(new List<Character>
        {
            new Character
                { Id = 1, FirstName = "Humster", LastName = "Humterewich", CurrentWeight = 200, MaxWeight = 500 },
            new Character { Id = 2, FirstName = "Asia", LastName = "Pers", CurrentWeight = 300, MaxWeight = 700 }
        });

        modelBuilder.Entity<Backpack>().HasData(new List<Backpack>
        {
            new Backpack { CharacterId = 1, ItemId = 1, Amount = 3 },
            new Backpack { CharacterId = 2, ItemId = 2, Amount = 1 }
        });



        modelBuilder.Entity<Title>().HasData(new List<Title>
        {
            new Title { Id = 1, Name = "Hero" },
            new Title { Id = 2, Name = "Mouse Hunter" }

        });

        modelBuilder.Entity<Character_Title>().HasData(new List<Character_Title>
        {

            new Character_Title { CharacterId = 1, TitleId = 1, AcquiredAt = new DateTime(2023, 10, 2, 5, 3, 10) },
            new Character_Title { CharacterId = 2, TitleId = 2, AcquiredAt = new DateTime(2020, 9, 4, 5, 3, 10) }

        });

    }
}
//dotnet ef migrations add Init
//dotnet ef database update