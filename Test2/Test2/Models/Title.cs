using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Title
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Character_Title> Character_Titles { get; set; } = new HashSet<Character_Title>();
    
}