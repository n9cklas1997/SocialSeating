using Microsoft.Data.SqlClient;

namespace Human
{
    class Person
    {
        // Private Fields
        private string? _PersonalityType; // ? is a feature in C# 8.0 to indicate that a variable is nullable.

        // Properties
        public string Name {get; set;}
    
        public int Age {get; set;}

        public string? PersonalityType
        {
            get { return _PersonalityType; }
            set
            {
                if (value == "INTJ-A" || value == "INTJ-T")
                {
                    _PersonalityType = value;
                }
                else
                    _PersonalityType = "no type specified";
            }
        }

        
        // Constructors
        public Person(string name, int age, string personalityType)
        {
            Name = name;
            Age = age;
            PersonalityType = personalityType;
        }

        // Method that takes a connection string to a database and inserts the attributes (name, age & personality type) of a person. 
        // Then the method returns the ID of said person.
        public object InsertPersonRecord(string connectionString)
    {
        using (SqlConnection sqlCon = new SqlConnection(connectionString))
        {
            sqlCon.Open();

            string cmdText = @"
                INSERT INTO PersonsTable (Name, Age, PersonalityType)
                VALUES (@name, @age, @personalityType);
                SELECT SCOPE_IDENTITY();
            ";

            using (SqlCommand cmd = new SqlCommand(cmdText, sqlCon))
            {
                cmd.Parameters.AddWithValue("name", Name);
                cmd.Parameters.AddWithValue("age", Age);
                cmd.Parameters.AddWithValue("personalityType", PersonalityType);
                
                return cmd.ExecuteScalar();
            }
        }
    }
    }
}