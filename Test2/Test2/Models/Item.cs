using System.ComponentModel.DataAnnotations;

namespace Test2.Models;

public class Item
{
    [Key]
    public int Id { get; set; }
    [MaxLength(100)]
    [Required]
    public string Name { set; get; }
    [Required]
    public int Weight { set; get; }

    public ICollection<Backpack> ListBackpacks { get; set; } = new HashSet<Backpack>();
    

}