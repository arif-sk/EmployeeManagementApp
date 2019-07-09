using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagementApp.Models
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        List<Employee> employees;
        public MockEmployeeRepository()
        {
            employees = new List<Employee>
            {
                new Employee{Id =1,Name="King Leo",Email="kingleo@gmail.com",Department="Software" },
                new Employee{Id =2,Name="Cr7",Email="cr7@gmail.com",Department="Hardware" },
                new Employee{Id =3,Name="Hazard",Email="hazard@outlook.com",Department="Network" },
            };
        }
        public List<Employee> GetEmployee()
        {
            return employees;
        }
        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

    }
}
