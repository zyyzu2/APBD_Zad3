using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.DTOs;

public class CreateAnimalDTO
{
    [Required, MaxLength(200)]
    public string Name { get; set; }
    [DefaultValue("")]
    public string Description { get; set; }
    [Required, MaxLength(200)]
    public string Category { get; set; }
    [Required, MaxLength(200)]
    public string Area { get; set; }
}