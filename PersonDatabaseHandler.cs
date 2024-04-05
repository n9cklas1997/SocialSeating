using Human;
using Microsoft.Data.SqlClient;

public class PersonDatabaseHandler
{
    private string _connectionString;


    public PersonDatabaseHandler(string connectionString)
    {
       _connectionString = connectionString;
    }
    
    public void InsertPersonRecord(Person person)
    {
        using (SqlConnection connection = new SqlConnection(_connectionString))
        {

            string commandText = 
                @"
                INSERT INTO PersonsTable (Name, Age, Personality)
                VALUES (@name, @age, @personality);
                SELECT SCOPE_IDENTITY();
                ";

            using (SqlCommand command = connection.CreateCommand())
            {
                command.CommandText = commandText;

                command.Parameters.AddWithValue("name", person.Name);
                command.Parameters.AddWithValue("age", person.Age);
                command.Parameters.AddWithValue("personality", person.Personality);
                
                connection.Open();
                object temp = command.ExecuteScalar();
                person.ID = Convert.ToInt32(temp);
            }
        }
    }

    public Person SelectPersonRecord(int personId)
    {
        Person? person = null;

        using (SqlConnection connection = new SqlConnection(_connectionString)) // Establish a connection
        {
            string commandText = 
                @"
                SELECT ID, Name, Age, Personality
                FROM PersonsTable
                WHERE ID = @personId
                ";
        
            using (SqlCommand command = new SqlCommand(commandText, connection)) // Create a SQL command that has a query and a connection as input.
            {
                command.Parameters.AddWithValue("@personId", personId);

                connection.Open();

                using (SqlDataReader reader = command.ExecuteReader()) // Executes the SQL command (Reader when you have a return value)
                {
                    if (reader.Read()) // If the correct ID is found
                    {
                        int idOrdinal = reader.GetOrdinal("ID");
                        int nameOrdinal = reader.GetOrdinal("Name");
                        int ageOrdinal = reader.GetOrdinal("Age");
                        int personalityOrdinal = reader.GetOrdinal("Personality");

                        int id = reader.GetInt32(idOrdinal);
                        string name = reader.GetString(nameOrdinal);
                        int age = reader.GetInt32(ageOrdinal);
                        string personality = reader.GetString(personalityOrdinal);
                        
                        person = new Person(id, name, age, personality);
                    }
                    else
                    {
                         throw new InvalidOperationException("Person record not found.");
                    }
                }
            }
        }
        
        return person;
    }

    public List<Person> SelectMultiplePersons(Dictionary<string, object> filters)
    {
        List<Person> persons = new List<Person>();

        using (SqlConnection connection = new SqlConnection(_connectionString))
        {
            string commandText = "SELECT ID, Name, Age, Personality FROM PersonsTable WHERE 1=1";
            SqlCommand command = new SqlCommand();
            command.Connection = connection;

            foreach (KeyValuePair<string, object> filter in filters)
            {
                commandText += $" AND {filter.Key} = @{filter.Key}";
                command.Parameters.AddWithValue($"@{filter.Key}", filter.Value);
            }

            command.CommandText = commandText;

            connection.Open();

            using (SqlDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    int idOrdinal = reader.GetOrdinal("ID");
                    int nameOrdinal = reader.GetOrdinal("Name");
                    int ageOrdinal = reader.GetOrdinal("Age");
                    int personalityOrdinal = reader.GetOrdinal("Personality");
                    
                    int id = reader.GetInt32(idOrdinal);
                    string name = reader.GetString(nameOrdinal);
                    int age = reader.GetInt32(ageOrdinal);
                    string personality = reader.GetString(personalityOrdinal);
                    
                    Person person = new Person(id, name, age, personality);
                    persons.Add(person);
                }
            }
        }

        return persons;
    }
 }
