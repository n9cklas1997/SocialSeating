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
                        int id = reader.GetInt32(0);
                        string name = reader.GetString(1);
                        int age = reader.GetInt32(2);
                        string personality = reader.GetString(3);
                        
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
 }
