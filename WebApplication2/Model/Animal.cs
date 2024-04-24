using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model;

public class Animal
{
    [Required]
    public int IdAnimal { get; set; }
    [Required, MaxLength(200)]
    public string Name { get; set; }
    public string Description { get; set; }
    [Required, MaxLength(200)]
    public string Category { get; set; }
    [Required, MaxLength(200)]
    public string Area { get; set; }
}