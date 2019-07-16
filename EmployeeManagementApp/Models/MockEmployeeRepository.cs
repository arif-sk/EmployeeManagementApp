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
                new Employee{Id =1,Name="King Leo",Email="kingleo@gmail.com",Department=Dept.IT },
                new Employee{Id =2,Name="Cr7",Email="cr7@gmail.com",Department=Dept.HR },
                new Employee{Id =3,Name="Hazard",Email="hazard@outlook.com",Department=Dept.Marketing},
            };
        }

        public Employee Add(Employee employee)
        {
            if (employees.Count > 0)
            {
                employee.Id = employees.Max(x => x.Id) + 1;
            }
            else
            {
                employee.Id = 1;
            }
            employees.Add(employee);
            return employee;
        }

        public Employee Delete(int id)
        {
            Employee employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee != null)
            {
                employees.Remove(employee);
            }
            return employee;
        }

        public List<Employee> GetEmployee()
        {
            return employees;
        }
        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(e => e.Id == id);
        }

        public Employee Update(Employee updateEmployee)
        {
            var employee = employees.FirstOrDefault(e => e.Id == updateEmployee.Id);
            if (employee != null)
            {
                employee.Name = updateEmployee.Name;
                employee.Email = updateEmployee.Email;
                employee.Department = updateEmployee.Department;
            }
            return employee;
        }
    }
}
