using Test2.Models;

namespace Test2.Services;

public interface IDBService
{
    public Task<Character> GetCharacterInfo(int id);

    public Task<bool> AddNewItem(List<int> List_ids);
}