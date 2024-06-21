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

    public Task<bool> AddNewItem(List<int> List_ids)
    {
        throw new NotImplementedException();
    }

    
}

    
