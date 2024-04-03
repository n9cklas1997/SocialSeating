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
    }
}