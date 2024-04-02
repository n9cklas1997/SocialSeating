namespace Human
{
    class Person
    {
        // Properties
        public string Name {get; set;}
    
        public int Age {get; set;}

        // Constructors
        public Person(string aName, int aAge)
        {
            Name = aName;
            Age = aAge;
        }
    }
}