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
        using (SqlConnection sqlCon = new SqlConnection(_connectionString))
        {
            sqlCon.Open();

            string cmdText = @"
                INSERT INTO PersonsTable (Name, Age, Personality)
                VALUES (@name, @age, @personality);
                SELECT SCOPE_IDENTITY();
            ";

            using (SqlCommand cmd = sqlCon.CreateCommand())
            {
                cmd.CommandText = cmdText;

                cmd.Parameters.AddWithValue("name", person.Name);
                cmd.Parameters.AddWithValue("age", person.Age);
                cmd.Parameters.AddWithValue("personality", person.Personality);
                
                object temp = cmd.ExecuteScalar();
                person.ID = Convert.ToInt32(temp);
            }
        }
    }

     public Person SelectPersonRecord(int personId)
    {
        Person? person = null;

        using (SqlConnection sqlCon = new SqlConnection(_connectionString)) // Establish a connection
        {
            sqlCon.Open();
            
            string cmdText = @"
                SELECT ID, Name, Age, Personality
                FROM PersonsTable
                WHERE ID = @personId
            ";

            using (SqlCommand cmd = new SqlCommand(cmdText, sqlCon)) // Create a SQL command that has a query and a connection as input.
            {
                cmd.Parameters.AddWithValue("@personId", personId);

                using (SqlDataReader reader = cmd.ExecuteReader()) // Executes the SQL command (Reader when you have a return value)
                {
                    if (reader.Read())
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
