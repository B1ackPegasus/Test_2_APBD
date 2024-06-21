using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Character
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(50)]
    [Required]
    public string FirstName { get; set; }
    
    [MaxLength(120)]
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public int CurrentWeight { get; set; }
    
    [Required]
    public int MaxWeight { get; set; }
    
    public ICollection<Backpack> ListBackpacks { get; set; } = new HashSet<Backpack>();
    
    public ICollection<Character_Title> Character_Titles { get; set; } = new HashSet<Character_Title>();
    
}