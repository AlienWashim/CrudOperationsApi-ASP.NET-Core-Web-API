using CrudOperationsApi;
using Microsoft.Data.SqlClient;
using CrudOperationsApi.Models;
using System;
using System.Collections.Generic;
using System.Data;

namespace CrudOperationsApi.Services
{
    public class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Get all persons
        public List<Person> GetPersons()
        {
            var persons = new List<Person>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Persons", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            persons.Add(new Person
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Salary = reader.GetDecimal(2)
                            });
                        }
                    }
                }
            }

            return persons;
        }

        // Get person by Id
        public Person GetPersonById(int id)
        {
            Person person = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("SELECT * FROM Persons WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            person = new Person
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                Salary = reader.GetDecimal(2)
                            };
                        }
                    }
                }
            }

            return person;
        }

        // Add new person
        public void AddPerson(Person person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("INSERT INTO Persons (Id, Name, Salary) VALUES (@Id, @Name, @Salary)", connection))
                {
                    command.Parameters.AddWithValue("@Id", person.Id);
                    command.Parameters.AddWithValue("@Name", person.Name);
                    command.Parameters.AddWithValue("@Salary", person.Salary);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Update existing person
        public void UpdatePerson(Person person)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("UPDATE Persons SET Name = @Name, Salary = @Salary WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", person.Id);
                    command.Parameters.AddWithValue("@Name", person.Name);
                    command.Parameters.AddWithValue("@Salary", person.Salary);
                    command.ExecuteNonQuery();
                }
            }
        }

        // Delete a person by Id
        public void DeletePerson(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new SqlCommand("DELETE FROM Persons WHERE Id = @Id", connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
