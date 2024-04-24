using WebApplication2.DTOs;
using WebApplication2.Model;

namespace WebApplication2.Services;

public interface IAnimalService
{
    public IEnumerable<Animal> GetAllAnimals(string orderBy);
    public bool AddAnimal(CreateAnimalDTO dto);
    public bool UpdateAnimal(int id, CreateAnimalDTO dto);
}


