using System.Data.SqlClient;
using WebApplication2.Model;

namespace WebApplication2.Repos;

public class AnimalRepository : IAnimalRepository
{
    private readonly IConfiguration _configuration;

    public AnimalRepository(IConfiguration configuration)
    {
        _configuration = configuration;
    }


    public IEnumerable<Animal> FetchAllAnimals(string orderBy)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        
        var safeOrderBy = new string[] { "Name", "Description", "Category", "Area" }.Contains(orderBy) ? orderBy : "Name";
        var command = new SqlCommand($"SELECT * FROM Animal ORDER BY {safeOrderBy}", connection);
        using var reader = command.ExecuteReader();

        var animals = new List<Animal>();
        while (reader.Read())
        {
            var animal = new Animal()
            {
                IdAnimal = (int)reader["IdAnimal"],
                Name = reader["Name"].ToString()!,
                Description = reader["Description"].ToString()!,
                Category = reader["Category"].ToString()!,
                Area = reader["Area"].ToString()!
            };
            animals.Add(animal);
        }

        return animals;
    }

    public bool CreateAnimal(string s)
    {
        throw new NotImplementedException();
    }
}