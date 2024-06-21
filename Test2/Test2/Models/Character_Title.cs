using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Test2.Models;
[PrimaryKey(nameof(CharacterId),nameof(TitleId))]
public class Character_Title
{
    public int CharacterId { get; set; }
    public int TitleId { get; set; }
    [Required]
    public DateTime AcquiredAt { get; set; }
    
    [ForeignKey(nameof(CharacterId))]
    public Character Character { get; set; } = null!;

    [ForeignKey(nameof(TitleId))] 
    public Title  Title{ get; set; } = null!;
    
    
}