using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test2.Data;
using Test2.Models;

namespace Test2.Services;

public class DBService : IDBService
{
    private readonly ApplicationContext _context;

    public DBService(ApplicationContext context)
    {
        _context = context;
    }

    public async Task<Character> GetCharacterInfo(int id)
    {
        var character = await _context.Character
            .Include(e => e.Character_Titles)
            .ThenInclude(e => e.Title)
            .Include(e => e.ListBackpacks)
            .ThenInclude(e => e.Item).FirstOrDefaultAsync(e => e.Id == id);
        return character;
    }

    public async Task<bool> AddNewItem(List<int> List_ids, int characterId)
    {
        var ItemsList = await _context.Item.Where(e => List_ids.Contains(e.Id)).ToListAsync();
        
        if (List_ids.Count != List_ids.Count)
        {
            return false;
        }

        var character = await _context.Character.Include(e => e.ListBackpacks).Where(e => e.Id == characterId).FirstOrDefaultAsync();

        if (character == null)
        {
            return false;
        }

        var weight = 0;
        
        foreach (var item in ItemsList)
        {
            weight += item.Weight;
        }

        var capacity = character.MaxWeight - character.CurrentWeight;

        if (weight > capacity)
        {
            return false;
        }

        character.CurrentWeight += weight;

        foreach (var item in ItemsList)
        {
            var currentItem = character.ListBackpacks.Where(e => e.ItemId == item.Id).FirstOrDefault();
            if (currentItem != null)
            {
                currentItem.Amount += 1;
            }
            else
            {
                character.ListBackpacks.Add(new Backpack()
                {
                    CharacterId = characterId,
                    Item = item,
                    Amount = 1
                });
            }
        }
        
        await _context.SaveChangesAsync();
        return true;
    }

    
}

    
