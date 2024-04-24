using WebApplication2.Model;

namespace WebApplication2.Services;

public interface IAnimalService
{
    public IEnumerable<Animal> GetAllAnimals(string orderBy);
}


