using Microsoft.AspNetCore.Mvc;
using Test2.Models;
using Test2.Services;

namespace Test2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class CharactersController : ControllerBase
{
   private readonly IDBService _dbService;

   public CharactersController(IDBService dbService)
   {
      _dbService = dbService;
   }

   [HttpGet("{characterId:int}")]
   public async Task<IActionResult> InfoAboutCharacter(int characterId)
   {
      var character = await _dbService.GetCharacterInfo(characterId);
      var result = new CharacterDto()
      {
         FirstName = character.FirstName,
         LastName = character.LastName,
         CurrentWeight = character.CurrentWeight,
         MaxWeight = character.MaxWeight,
         BackpackItems = character.ListBackpacks.Select(e => new BackpackDTO()
         {
            itemName = e.Item.Name,
            itemWeight = e.Item.Weight,
            Amount = e.Amount
         }).ToList(),
         Titles = character.Character_Titles.Select(e => new TitleDTO()
         {
            Title = e.Title.Name,
            AquiredAt = e.AcquiredAt
         }).ToList()
      };
      return Ok(result);
   }
   
   [HttpPost("{characterid:int}/backpacks")]
   public async Task<IActionResult> AddNewItem(List<int> List_ids,int characterid)
   {
      var result = await _dbService.AddNewItem(List_ids, characterid);
      if (!result)
      {
         return NotFound("List contains an item that does not exist");
      }

      var ItemList = _dbService.GetCharacterInfo(characterid).Result.ListBackpacks
         .Where(e => List_ids.Contains(e.Item.Id)).ToList();
      var resultList = ItemList.Select(e => new AddItemDTO()
      {
         Amount = e.Amount,
         ItemId = e.ItemId,
         CharacterId = e.CharacterId
      });
      return Ok(resultList);
   }
}