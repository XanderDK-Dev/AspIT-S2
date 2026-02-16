using Entities;
using Microsoft.Data.SqlClient;
using System;
namespace DataAccess
{
    public class DataHandler
    {
        string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=UniDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30";
        public List<Person> GetAllPersons()
        {
            List<Person> items = new();

            string sql = "SELECT * FROM Persons";
            SqlConnection connection = new(connectionString);
            SqlCommand command = new(sql, connection);
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int personID = reader.GetInt32(0);
                string firstName = reader.GetString(3);
                string lastName = reader.GetString(4);

                Person person = new()
                {
                    PersonID = personID,
                    FirstName = firstName,
                    LastName = lastName
                };
                items.Add(person);
            }


            connection.Close();
            return items;

        }
    

        public void AddNewPerson(Person person)
        {
            string sql = $"INSERT INTO Persons (firstName, lastName) VALUES ('{person.FirstName}', '{person.LastName}');";
            SqlConnection connection = new(connectionString);
            SqlCommand command = new(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void UpdatePerson(Person person)
        {
            string sql = $"UPDATE Persons SET Firstname = '{person.FirstName}', Lastname = '{person.LastName}' WHERE PersonID = {person.PersonID};";
            SqlConnection connection = new(connectionString);
            SqlCommand command = new(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void DeletePerson(Person person)
        {
            string sql = $"DELETE FROM Persons WHERE PersonID = {person.PersonID};";
            SqlConnection connection = new(connectionString);
            SqlCommand command = new(sql, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        }
    }
}