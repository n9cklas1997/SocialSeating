using Human;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting my connection string for my database.
            string connectionString = "Super secret connection string";
            
            // Creating an instances of classes
            var person = new Person("update", 111, "wrong");
            var personDatabaseHandler = new PersonDatabaseHandler(connectionString);

            
            // var person2 = personDatabaseHandler.SelectPersonRecord(1);

            // Console.WriteLine(person2.Age);
            
            // person.Age = 10;
            // person.Name = "John";
            // person.Personality = "wrong";

            // Calling the InsertPersonRecord method for a person and printing out the ID.
            
                   
            personDatabaseHandler.InsertPersonRecord(person);
            // Console.WriteLine("Inserted record's ID is: " + person.ID);
        }
    }
}

