using WebApplication2.Model;

namespace WebApplication2.Repos;

public interface IAnimalRepository
{
    public IEnumerable<Animal> FetchAllAnimals(string orderBy);
    public bool CreateAnimal(string name, string description, string category, string area);
    bool UpdateAnimal(int id, string dtoName, string dtoDescription, string dtoCategory, string dtoArea);
}