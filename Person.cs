using Microsoft.Data.SqlClient;

namespace Human
{
    public class Person
    {
        // Private Fields
        private string? _Personality; // ? is a feature in C# 8.0 to indicate that a variable is nullable.

        // Properties
        public int ID {get; set;}
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
            ID = int.MinValue;
        }
    }
}