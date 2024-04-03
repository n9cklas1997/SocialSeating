using Microsoft.Data.SqlClient;

namespace Human
{
    class Person
    {
        // Private Fields
        private string? _Personality; // ? is a feature in C# 8.0 to indicate that a variable is nullable.

        // Properties
        public string Name {get; set;}
    
        public int Age {get; set;}

        public string? Personality // When setting a value, we check if the value is null and if is in the Enum called PersonalityTypes
        {
            get { return _Personality; }
            set
            {
                if (value != null && Enum.IsDefined(typeof(PersonalityType), value))
                {
                    _Personality = value;
                }
                else
                    _Personality = "no type specified";
            }
        }

        
        // Constructors
        public Person(string name, int age, string personality)
        {
            Name = name;
            Age = age;
            Personality = personality;
        }

        // Method that takes a connection string to a database and inserts the attributes (name, age & personality type) of a person. 
        // Then the method returns the ID of said person.
        public int InsertPersonRecord(string connectionString)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();

                string cmdText = @"
                    INSERT INTO PersonsTable (Name, Age, Personality)
                    VALUES (@name, @age, @personality);
                    SELECT SCOPE_IDENTITY();
                ";

                using (SqlCommand cmd = sqlCon.CreateCommand()) // SqlCommand cmd = new SqlCommand(cmdText, sqlCon) also possible
                {
                    cmd.CommandText = cmdText;

                    cmd.Parameters.AddWithValue("name", Name);
                    cmd.Parameters.AddWithValue("age", Age);
                    cmd.Parameters.AddWithValue("personality", Personality);
                    
                    return (int) cmd.ExecuteScalar();
                }
            }
        }
    }
}