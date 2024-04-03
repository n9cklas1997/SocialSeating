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
            Person person = new Person("WHA", 30, "INTP_T");

            // Calling the InsertPersonRecord method for this person and saving the ID so I can print it out.
            object ID = person.InsertPersonRecord(connectionString);
            Console.WriteLine("Inserted record's ID is: " + ID);
        }
    }
}

