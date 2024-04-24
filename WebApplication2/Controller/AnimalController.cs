using Microsoft.AspNetCore.Mvc;
using WebApplication2.Services;

namespace WebApplication2.Controller;

[ApiController]
[Route("/api/animals")]
public class AnimalController(IAnimalService animalService) : ControllerBase
{
    private readonly IAnimalService _animalService = animalService;

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAllAnimals([FromQuery] string orderBy)
    {
        var animals = _animalService.GetAllAnimals(orderBy);
        return Ok(animals);
    }
}