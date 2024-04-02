using Human;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Person person1 = new Person("Lars", 26, "INTJ-A");
            Person person2 = new Person("Frederik", 29, "INTJ-T");

            //Showcase different ways of printning
            Console.WriteLine($"{person1.Name} is {person1.Age} years old and has the personality of a {person1.PersonalityType}");
            Console.WriteLine(person2.Name + " is " + person2.Age + " years old and has the personality of a " + person2.PersonalityType);

            
            Console.ReadKey();
        }
    }
}

