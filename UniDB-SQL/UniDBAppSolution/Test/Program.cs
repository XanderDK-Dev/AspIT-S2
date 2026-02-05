using DataAccess;
using Entities;
namespace Test
{
    internal class Program
    {

        static void SqlDatabase()
        {
            var persons = DataHandler.GetAllPersons();
            
            persons = DataHandler.GetAllPersons();

            foreach (var person in persons)
            {
                Console.WriteLine($"ID: {person.PersonID}, Name: {person.FirstName} {person.LastName}");
            }
        }
        static void Main(string[] args)
        {
            SqlDatabase();
            Console.WriteLine("If you wish to create a new person press A \\If you wish to update a person press B \\If you wish to delete a person press C");
            string character = Console.ReadLine();
            if (character.ToLower() == "a")
            {
                Console.WriteLine("Whats the first name?");
                string firstname = Console.ReadLine();
                Console.WriteLine("Whats the last name?");
                string lastname = Console.ReadLine();

                Person newPerson = new Person
                {
                    FirstName = firstname,
                    LastName = lastname
                };
                DataHandler.AddNewPerson(newPerson);
                SqlDatabase();
            }
            else if (character.ToLower() == "b")
            {
                Console.WriteLine("Whats the ID?");
                int personid = int.Parse(Console.ReadLine());
                Console.WriteLine("What should the first name be changed to?");
                string firstname = Console.ReadLine();
                Console.WriteLine("What should the last name be changed to?");
                string lastname = Console.ReadLine();

                Person updatedPerson = new Person
                {
                    PersonID = personid,
                    FirstName = firstname,
                    LastName = lastname
                };
                DataHandler.UpdatePerson(updatedPerson);
                SqlDatabase();
            }
            else if (character.ToLower() == "c")
            {
                Console.WriteLine("Whats the ID?");
                int personid = int.Parse(Console.ReadLine());
                Console.WriteLine($"Are you sure you want to delete {personid} Y/N");
                string answer = Console.ReadLine();
                if (answer.ToLower() == "y")
                {
                    Person deletedPerson = new Person
                    {
                        PersonID = personid
                    };
                    DataHandler.DeletePerson(deletedPerson);
                    SqlDatabase();
                }
            }
        }
    }
}
