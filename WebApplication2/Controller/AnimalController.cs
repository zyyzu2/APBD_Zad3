using Microsoft.AspNetCore.Mvc;
using WebApplication2.DTOs;
using WebApplication2.Services;

namespace WebApplication2.Controller;

[ApiController]
[Route("/api/animals")]
public class AnimalController(IAnimalService animalService) : ControllerBase
{
    private readonly IAnimalService _animalService = animalService;

    [HttpGet("")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public IActionResult GetAllAnimals([FromQuery] string orderBy = "")
    {
        var animals = _animalService.GetAllAnimals(orderBy);
        return Ok(animals);
    }

    [HttpPost]
    public IActionResult CreateAnimal([FromBody] CreateAnimalDTO dto)
    {
        var success = _animalService.AddAnimal(dto);
        return success ? StatusCode(StatusCodes.Status201Created) : Conflict();
    }

    [HttpPut("{idAnimal:int}")]
    public IActionResult UpdateAnimal([FromRoute] int idAnimal, [FromBody] CreateAnimalDTO dto)
    {
        var success = _animalService.UpdateAnimal(idAnimal, dto);
        return success ? StatusCode(StatusCodes.Status200OK) : Conflict();
    }
}