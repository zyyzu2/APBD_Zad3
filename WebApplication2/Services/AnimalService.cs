using WebApplication2.Model;
using WebApplication2.Repos;

namespace WebApplication2.Services;

public class AnimalService : IAnimalService
{

    private readonly IAnimalRepository _animalRepository;

    public AnimalService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }
    
    public IEnumerable<Animal> GetAllAnimals(string orderBy)
    {
        return _animalRepository.FetchAllAnimals(orderBy);
    }
}