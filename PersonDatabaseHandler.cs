using Human;
using Microsoft.Data.SqlClient;

public class PersonDatabaseHandler
{
    // Method that takes a connection string to a database and inserts the attributes (name, age & personality type) of a person. 
    // Then the method returns the ID of said person.
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
                
                var dum = cmd.ExecuteScalar();
                person.ID = Convert.ToInt32(dum);
            }
        }
    }
}