using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
    
namespace Notes.Database.Models;
    
[Table("project")]
[PrimaryKey(nameof(Id))]
public class Project
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    [Required]
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public List<Note> Notes { get; set; } = new List<Note>();}