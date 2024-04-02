using Human;

namespace MyProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Person person1 = new Person("Lars", 26);
            Person person2 = new Person("Frederik", 29);

            Console.WriteLine(person1.Age);
            Console.WriteLine(person2.Name);

            
            Console.ReadKey();
        }
    }
}

