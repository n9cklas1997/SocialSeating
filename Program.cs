using Human;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting my connection string for my database.
            string connectionString = "Data Source=DESKTOP-8G6DJAM\\SQLEXPRESS;Initial Catalog=SocialSeating;Integrated Security=True;Encrypt=False";
            
            // Creating an instance of the Person class
            var person = new Person("test123123", 123, "INTP_T");
            var personDatabaseHandler = new PersonDatabaseHandler(connectionString);

            // Calling the InsertPersonRecord method for this person and saving the ID so I can print it out.
            personDatabaseHandler.InsertPersonRecord(person);
            Console.WriteLine("Inserted record's ID is: " + person.ID);
        }
    }
}

