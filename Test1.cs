using MySql.Data.MySqlClient;
using System;

namespace Employee1
{
    class Test1
    {
        private static string conStr = "Server=localhost;Database=employee;Uid=root;Pwd=sandy;";
        private static MySqlConnection connection = new MySqlConnection(conStr);

        public static void InsertEmployee()
        {
            try
            {
                Console.WriteLine("Enter the id,name,role,age and salary-----");
                int id = Convert.ToInt32(Console.ReadLine());
                string name = Console.ReadLine();
                string department = Console.ReadLine();
                int age = Convert.ToInt32(Console.ReadLine());
                int salary = Convert.ToInt32(Console.ReadLine());
                string query = "INSERT INTO employee(id, employee_name, department, age, salary) VALUES (@id, @name, @department, @age, @salary)";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@department", department); 
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@salary", salary);
                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                cmd.ExecuteNonQuery();
                Console.WriteLine("Student inserted successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
           
                    connection.Close();
            
        }

        public static void ViewEmployees() {
            try
            {
                string query = "SELECT * FROM employee";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                Console.WriteLine("\nEmployees are:-");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["id"]}, Name: {reader["employee_name"]}, Role: {reader["department"]}, Age: {reader["age"]}, Salary: {reader["salary"]}");
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            
                    connection.Close();
            
        }
        public static void UpdateEmployee() {
            try
            {
                Console.Write("Enter ID of employee to update: ");
                int id = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter New Department: ");
                string department = Console.ReadLine();

                Console.Write("Enter New Age: ");
                int age = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter New Salary: ");
                int salary = Convert.ToInt32(Console.ReadLine());

                string query = "UPDATE employee SET employee_name=@name, department=@department, age=@age, salary=@salary WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@department", department);
                cmd.Parameters.AddWithValue("@age", age);
                cmd.Parameters.AddWithValue("@salary", salary);

                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Employee updated successfully!");
                else
                    Console.WriteLine("No employee found with the given ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            
                    connection.Close();
            
        }
        public static void DeleteEmployee() {
            try
            {
                Console.Write("Enter ID of employee to delete: ");
                int id = Convert.ToInt32(Console.ReadLine());

                string query = "DELETE FROM employee WHERE id=@id";
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);

                if (connection.State != System.Data.ConnectionState.Open)
                    connection.Open();

                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                    Console.WriteLine("Employee deleted successfully!");
                else
                    Console.WriteLine("No employee found with the given ID.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
           
                    connection.Close();
            
        }

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n Employee Management System");
                Console.WriteLine("1. Insert Employee");
                Console.WriteLine("2. View Employee");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("Enter your choice:");
                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        InsertEmployee();
                        break;
                    case 2:
                        ViewEmployees();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
        }
    }
}
