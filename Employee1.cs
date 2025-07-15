using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee1
{
    class Employee1
    {
        private int id;
        private string employee_name;
        private string department;
        private int age;
        private int salary;

        public Employee1(int id, string employee_name, string department, int age, int salary)
        {
            this.id = id;
            this.employee_name = employee_name;
            this.department = department;
            this.age = age;
            this.salary = salary;
        }

        public int Id { get; set; }
        public string Employee_name { get; set; }
        public string Department { get; set; }

        public int Age { get; set; }

        public int Salary { get; set; }



    }
}
