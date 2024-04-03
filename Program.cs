using Human;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting my connection string for my database.
            string connectionString = "Super secret connection string";
            
            // Creating an instance of the Person class
            var person = new Person("test123123", 123, "INTP_T");
            var personDatabaseHandler = new PersonDatabaseHandler(connectionString);

            // Calling the InsertPersonRecord method for this person and saving the ID so I can print it out.
            personDatabaseHandler.InsertPersonRecord(person);
            Console.WriteLine("Inserted record's ID is: " + person.ID);
        }
    }
}

