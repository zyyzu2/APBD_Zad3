using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Model;

public class Animal
{
    [Required]
    public int IdAnimal { get; set; }
    [Required, MaxLength(200)]
    public String Name { get; set; }
    public String Description { get; set; }
    [Required, MaxLength(200)]
    public String Category { get; set; }
    [Required, MaxLength(200)]
    public String Area { get; set; }
}