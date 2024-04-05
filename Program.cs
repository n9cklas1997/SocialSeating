using Human;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // Setting my connection string for my database.
            string connectionString = "Super secret connectionString";

            // Creating an instances of classes
            var person = new Person("update", 99, "wrong");
            var personDatabaseHandler = new PersonDatabaseHandler(connectionString);

            
            // var person2 = personDatabaseHandler.SelectPersonRecord(1);

            // Console.WriteLine(person2.Age);
            
            // person.Age = 10;
            // person.Name = "John";
            // person.Personality = "wrong";

            // Calling the InsertPersonRecord method for a person and printing out the ID.
            
                   
            // personDatabaseHandler.InsertPersonRecord(person);

            Dictionary<string, object> filters = new Dictionary<string, object>();
            filters.Add("Age", "99");

            List<Person> persons = personDatabaseHandler.SelectMultiplePersonRecords(filters);

            foreach(Person p in persons)
            {
                Console.WriteLine(p.Personality);
            }


            // Console.WriteLine("Inserted record's ID is: " + person.ID);
        }
    }
}

