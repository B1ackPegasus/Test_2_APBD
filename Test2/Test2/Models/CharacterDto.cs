namespace Test2.Models;

public class CharacterDto
{
   
    public string FirstName { get; set; }
    
 
    public string LastName { get; set; }
    

    public int CurrentWeight { get; set; }
    

    public int MaxWeight { get; set; }
    
    public ICollection<BackpackDTO> BackpackItems { get; set; } = new HashSet<BackpackDTO>();
    public ICollection<TitleDTO> Titles { get; set; } = new HashSet<TitleDTO>();
}