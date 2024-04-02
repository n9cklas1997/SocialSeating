namespace Human
{
    class Person
    {
        // Private Fields
        private string? personalityType; // ? is a feature in C# 8.0 to indicate that a variable is nullable.

        // Properties
        public string Name {get; set;}
    
        public int Age {get; set;}

        public string? PersonalityType
        {
            get { return personalityType; }
            set
            {
                if (value == "INTJ-A" || value == "INTJ-T")
                {
                    personalityType = value;
                }
                else
                    personalityType = "no type specified";
            }
        }

        
        // Constructors
        public Person(string aName, int aAge, string aPersonalityType)
        {
            Name = aName;
            Age = aAge;
            PersonalityType = aPersonalityType;

        }
    }
}