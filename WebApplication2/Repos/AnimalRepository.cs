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

    public bool CreateAnimal(string name, string description, string category, string area)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        
        using var command = new SqlCommand("INSERT INTO Animal (Name, Description, CATEGORY, AREA) VALUES (@name, @desc, @cat, @area)", connection);
        command.Parameters.AddWithValue("@name", name);
        command.Parameters.AddWithValue("@desc", description);
        command.Parameters.AddWithValue("@cat", category);
        command.Parameters.AddWithValue("@area", area);
        var affectedRows = command.ExecuteNonQuery();
        return affectedRows == 1;
    }

    public bool UpdateAnimal(int id, string dtoName, string dtoDescription, string dtoCategory, string dtoArea)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        
        using var command = new SqlCommand("UPDATE Animal SET Name = @name, Description = @desc, CATEGORY = @cat, AREA = @area WHERE IdAnimal = @id", connection);
        command.Parameters.AddWithValue("@name", dtoName);
        command.Parameters.AddWithValue("@id", id);
        command.Parameters.AddWithValue("@desc", dtoDescription);
        command.Parameters.AddWithValue("@cat", dtoCategory);
        command.Parameters.AddWithValue("@area", dtoArea);
        
        var affectedRows = command.ExecuteNonQuery();
        return affectedRows == 1;
    }

    public bool DeleteAnimal(int id)
    {
        using var connection = new SqlConnection(_configuration["ConnectionStrings:DefaultConnection"]);
        connection.Open();
        
        using var command = new SqlCommand("DELETE FROM Animal WHERE IdAnimal = @id", connection);
        command.Parameters.AddWithValue("@id", id);
        var affectedRows = command.ExecuteNonQuery();
        return affectedRows == 1;
    }
}